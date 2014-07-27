using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Diagnostics;
using System.Web;
using System.Web.Script.Serialization;
using System.Threading;

namespace WindowsFormsApplication1
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private string getBadooResponse(string requestUrl)
        {
            string responseString = "";
            HttpWebRequest request = getBadooRequest(requestUrl);
            HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            using (StreamReader reader = new StreamReader(response.GetResponseStream()))
            {
                responseString = reader.ReadToEnd();
                response.Close();
            }
            return responseString;
        }

        private HttpWebRequest getBadooRequest(string requestUrl)
        {
            string url = "http://badoo.com/" + requestUrl;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.CookieContainer = new CookieContainer();
            request.CookieContainer.Add(new Uri("http://badoo.com"),
            new Cookie("s1", badooData.cookieS1));
            return request;
        }

        private void getUsers(string inputData)
        {
            var jss = new JavaScriptSerializer();
            var dict = jss.Deserialize<dynamic>(inputData);
            inputData = dict["html"].ToString();
            while (true)
            {
                if (inputData.IndexOf("\"user-card\"") < 0) break;
                int startPos;
                int endPos;
                startPos = inputData.IndexOf("\"user-card\"") + 4;
                inputData = inputData.Substring(startPos);
                string imageUrl = "";
                startPos = inputData.IndexOf("src") + 5;
                imageUrl = inputData.Substring(startPos);
                endPos = imageUrl.IndexOf("\"");
                imageUrl = imageUrl.Substring(0, endPos);

                string faceName = "";
                string id = "";
                startPos = inputData.IndexOf("user-status") + 16;
                inputData = inputData.Substring(startPos);
                startPos = inputData.IndexOf("badoo.com/") + 10;
                inputData = inputData.Substring(startPos);
                endPos = inputData.IndexOf("/");
                id = inputData.Substring(0, endPos).Trim();

                startPos = inputData.IndexOf(">") + 1;
                inputData = inputData.Substring(startPos);
                endPos = inputData.IndexOf("a>")-2;
                faceName = inputData.Substring(0, endPos).Trim();
                
                string href = "http://badoo.com/" + id;
                
                badooUser newUser = new badooUser();
                Int32.TryParse(id, out newUser.Id);
                newUser.Image = imageUrl;
                newUser.Name = faceName;
                newUser.Href = href;

                if (newUser.Id == 0) continue;

                badooUser pp = new badooUser();
                if (badooSearch.searchedUsers.TryGetValue(newUser.Id,out pp)==true)
                {
                    continue;
                }
                badooSearch.searchedUsers.Add(newUser.Id, newUser); 
            }
        }

        private void refreshList()
        {
            listBox1.Items.Clear();
            foreach (var currentUser in badooSearch.searchedUsers)
            {
                listBox1.Items.Add(currentUser.Value.Name + " - " + currentUser.Key.ToString());
            }
            listBox1.Refresh();
        }

        private void getOnlineUsers()
        {
            statusText.Text = "searching...";
            statusText.Refresh();
            badooSearch.searchedUsers.Clear();
            for (int i = 1; i <= pagesCount.Value; i++)
            {
                statusText.Text = "searching page " + i + ", wait...";
                statusText.Refresh();
                string resultHtml = getBadooResponse("search/?filter=online&hold=0&ws=1&rt=" + badooData.RT);//+"&page="+i
                //resultHtml = resultHtml.Replace("\\", "");
                getUsers(resultHtml);
                refreshList();
            }
            statusText.Text = "ready";
            statusText.Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            getOnlineUsers();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == "") return;
            foreach (var currentUser in badooSearch.searchedUsers)
            {
                string userId = currentUser.Value.Id.ToString();
                statusText.Text = "sending to" + userId;
                statusText.Refresh();
                string requestUrl = "connections/ws-post.phtml?ws=1&rt=" + badooData.RT + "&contact_user_id=" + userId + "&message=" + textBox1.Text;
                Form1.getBadooAsync(requestUrl);
            }
            statusText.Text = "ready";
            statusText.Refresh();
            checkUsers();
            refreshList();
        }
        private bool getBadooMessageRemove(string requestUrl, int userId)
        {
            HttpWebRequest request = getBadooRequest(requestUrl);
            try
            {
                HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    string jsonResult = reader.ReadToEnd();
                    response.Close();
                    var jss = new JavaScriptSerializer();
                    var dict = jss.Deserialize<dynamic>(jsonResult);
                    int messageCount = dict["data"]["info"]["messages_total"];
                    int chatDisabled = dict["data"]["messages"]["chat_disabled"];
                    if (messageCount > 0 || chatDisabled > 0)
                    {
                        return true;

                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch { }
            return false;
        }

        private void checkUsers()
        {
            statusText.Text = "checking users";
            statusText.Refresh();
            List<int> usersToRemove = new List<int>();
            foreach (var currentUser in badooSearch.searchedUsers)
            {
                int userId = currentUser.Value.Id;
                statusText.Text = "checking user " + userId.ToString();
                statusText.Refresh();
                if (getBadooMessageRemove("connections/ws-load-user.phtml?ws=1&rt=" + badooData.RT + "&contact_user_id=" + userId.ToString(), userId))
                {
                    usersToRemove.Add(userId);
                }
            }
            foreach (int removeUserId in usersToRemove)
            {
                badooSearch.searchedUsers.Remove(removeUserId);
            }
            refreshList();
            statusText.Text = "ready";
            statusText.Refresh();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            checkUsers();
        }

        private void openWebProfile()
        {
            if (listBox1.SelectedIndex >= 0)
            {
                string href = badooSearch.searchedUsers.ElementAt(listBox1.SelectedIndex).Value.Href;
                Process.Start(href);
            }
        }

        private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            openWebProfile();
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if (listBox1.SelectedIndex < 0)
            {
                contextMenuStrip1.Enabled = false;
            }
            else
            {
                contextMenuStrip1.Enabled = true;
            }
        }

        private void showWebProfileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openWebProfile();
        }

        private void removeFromThisListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex >= 0)
            {
                badooSearch.searchedUsers.Remove(badooSearch.searchedUsers.ElementAt(listBox1.SelectedIndex).Key);
                refreshList();
            }
        }

        private void writeMessageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex >= 0)
            {
                int userId = badooSearch.searchedUsers.ElementAt(listBox1.SelectedIndex).Key;
                badooData.selectedUser = userId;
                if (badooData.chatUsers.ContainsKey(userId) == false)
                {
                    badooData.chatUsers.Add(userId, badooSearch.searchedUsers.ElementAt(listBox1.SelectedIndex).Value);
                }
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
