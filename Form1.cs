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
using System.Reflection;
using System.Web;
using System.Web.Script.Serialization;
using System.Threading;
using Utility.ModifyRegistry;
using System.Diagnostics;



namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        int globalTimer = 0;
        bool activated = false;
        public static Mutex badooUsersMutex = new Mutex();
        public static Mutex badooFavUsersMutex = new Mutex();
        public static Mutex actualMessagesMutex = new Mutex();
        public Form1()
        {
            InitializeComponent();
            badooData.myUserId = "";
            badooData.logged = 0;
            badooData.cookieS1 = "5656";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            getUserList();
        }

        private void updateUserListMore()
        {
            ThreadPool.QueueUserWorkItem(o =>
            {
                List<int> userKeys = new List<int>();
                badooUsersMutex.WaitOne();
                foreach (var currentBadooUser in badooData.chatUsers)
                {
                    if (currentBadooUser.Value.Town == "" && currentBadooUser.Key!=24)
                    {
                        userKeys.Add(currentBadooUser.Key);
                    }
                }
                badooUsersMutex.ReleaseMutex();

                foreach (int userKey in userKeys)
                {
                    string htmlResult = getBadooResponse("0" + userKey + "/");

                    string Town = ""; 
                    int Age = 0;
                    int startPos = 0;
                    int endPos = 0;
                    startPos = htmlResult.IndexOf("title-age");
                    if (startPos != -1)
                    {
                        htmlResult = htmlResult.Substring(startPos);
                        startPos = htmlResult.IndexOf(">") + 1;
                        htmlResult = htmlResult.Substring(startPos);
                        endPos = htmlResult.IndexOf("span") - 2;
                        string AgeString = htmlResult.Substring(0, endPos).Trim();
                        Int32.TryParse(AgeString, out Age);
                    }
                    startPos = htmlResult.IndexOf("pf_loc_str");
                    if (startPos != -1)
                    {

                        htmlResult = htmlResult.Substring(startPos);
                        startPos = htmlResult.IndexOf(">") + 1;
                        htmlResult = htmlResult.Substring(startPos);
                        endPos = htmlResult.IndexOf("<");
                        Town = htmlResult.Substring(0, endPos);
                    }
                    badooUsersMutex.WaitOne();
                    if (badooData.chatUsers.ContainsKey(userKey))
                    {
                        badooData.chatUsers[userKey].Age = Age;
                        badooData.chatUsers[userKey].Town = Town;
                    }
                    badooUsersMutex.ReleaseMutex();
                }
                
            });
        }

        private void getUserList()
        {
            ThreadPool.QueueUserWorkItem(o =>
            {
               int newMessagesTotal = 0;
               try
               {   
                for (int i = 1; i <= pagesCount.Value; i++)
                {
                    string page = "";
                    if (i > 1) page = "&page=" + i.ToString();
                    string jsonResult = getBadooResponse("connections/ws-list.phtml?filter=online&ws=1&rt="+badooData.RT + page);
                    var jss = new JavaScriptSerializer();
                    var dict = jss.Deserialize<dynamic>(jsonResult);
                    string user_id = dict["vars"]["user_id"].ToString();
                    if (dict["errno"] != 0)
                    {
                        //logOut();
                        return;
                    }
                    badooUsersMutex.WaitOne();
                    foreach (var pair in dict["data"]["list"])
                    {
                        badooUser newBadooUser = new badooUser();
                        newBadooUser.Image = getImageUrl(pair["html"].ToString());
                        newBadooUser.Name = pair["name"].ToString();
                        newBadooUser.MessagesCount = pair["messages_total"];
                        newBadooUser.MessagesNew = pair["messages_new"];
                        newMessagesTotal += newBadooUser.MessagesNew;
                        newBadooUser.Id = pair["user_id"];
                        if (badooData.chatUsers.ContainsKey(pair["user_id"]))
                        {
                            badooData.chatUsers[pair["user_id"]].MessagesCount = newBadooUser.MessagesCount;
                            badooData.chatUsers[pair["user_id"]].MessagesNew = newBadooUser.MessagesNew;
                        }
                        else
                        {
                            badooData.chatUsers.Add(newBadooUser.Id, newBadooUser);
                        }
                    }
                    badooUsersMutex.ReleaseMutex();
                }
               }
                catch
               {}
               badooData.newMessagesTotal = newMessagesTotal;
            });
        }

        private void getUserListFav()
        {
            ThreadPool.QueueUserWorkItem(o =>
            {

                try
                {
                    for (int i = 1; i <= pagesCount.Value; i++)
                    {
                        badooFavUsersMutex.WaitOne();
                        string page = "";
                        if (i > 1) page = "&page=" + i.ToString();
                        string jsonResult = getBadooResponse("connections/your-favorites/?wa=1&ws=1&rt" + badooData.RT + page);
                        var jss = new JavaScriptSerializer();
                        var dict = jss.Deserialize<dynamic>(jsonResult);
                        
                        foreach (var pair in dict["vars"]["Contacts"]["contacts"])
                        {
                            badooUser newBadooUser = new badooUser();
                            newBadooUser.Name = pair.Key.ToString();
                            newBadooUser.Id = Int32.Parse(pair.Key);
                            if (badooData.favUsers.ContainsKey(newBadooUser.Id))
                            {
                                badooData.favUsers[newBadooUser.Id].MessagesCount = newBadooUser.MessagesCount;
                                badooData.favUsers[newBadooUser.Id].MessagesNew = newBadooUser.MessagesNew;
                            }
                            else
                            {
                                badooData.favUsers.Add(newBadooUser.Id, newBadooUser);
                            }
                        }
                        badooFavUsersMutex.ReleaseMutex();
                    }
                }
                catch (Exception e)
                { MessageBox.Show(e.ToString()); }
            });
        }

        private void getFavDetailed()
        {
            List<int> favUsersKey = new List<int>();
            badooFavUsersMutex.WaitOne();
            foreach (var currentBadooUser in badooData.favUsers)
            {
                if (currentBadooUser.Key.ToString() == currentBadooUser.Value.Name)
                {
                    favUsersKey.Add(currentBadooUser.Key);
                }
            }
            badooFavUsersMutex.ReleaseMutex();
            foreach (var currentBadooUser in favUsersKey)
            {
                int userId = currentBadooUser;
                ThreadPool.QueueUserWorkItem(o =>
                {
                   string jsonResult = getBadooResponse("connections/ws-load-user.phtml?ws=1&rt=" + badooData.RT + "&contact_user_id=" + userId.ToString());
                   var jss = new JavaScriptSerializer();
                   var dict = jss.Deserialize<dynamic>(jsonResult);
                   badooFavUsersMutex.WaitOne();
                   badooData.favUsers[userId].Name = dict["data"]["info"]["name"].ToString();
                   badooData.favUsers[userId].Image = getImageUrl(dict["data"]["info"]["html"].ToString());
                   badooData.favUsers[userId].Status = (dict["data"]["info"]["status"].ToString() == "online") ? 1 : 0;
                   badooData.favUsers[userId].MessagesNew = (dict["data"]["messages"]["read_status"].ToString() == "unread") ? 1 : 0;
                   badooFavUsersMutex.ReleaseMutex();
               });
            }
            
        }

        private void logOut()
        {
            getBadooResponse("?signout=1");
            badooData.cookieS1 = "";
            badooData.RT = "";
            loginButton.Enabled = true;
            logoutButton.Enabled = false;
            searcherButton.Enabled = false;
            textBox1.Text = "";
            newMsgTxtBox.Text = "";
            usersListBox.Items.Clear();
            newMsgTxtBox.Enabled = false;
            sendButton.Enabled = false;
            textBox1.Enabled = false;
            usersListBox.Enabled = false;
            timerRedrawAll.Enabled = false;
            statusBar.Text = "Logged out";
            badooData.chatUsers.Clear();
            updateDebugInfo();
        }

        private void logInPost()
        {
            loginButton.Enabled = false;
            logoutButton.Enabled = true;
            searcherButton.Enabled = true;
            newMsgTxtBox.Enabled = true;
            sendButton.Enabled = true;
            textBox1.Enabled = true;
            usersListBox.Enabled = true;
            timerRedrawAll.Enabled = true;
            statusBar.Text = "Logged in";
            updateDebugInfo();
        }

        private string getCookie(string cookieName, HttpWebResponse response)
        {
            string cookieValue = "";
            string allHeaders = response.Headers.ToString();
            int startPos = allHeaders.LastIndexOf(cookieName+"=") + cookieName.Length + 1;
            cookieValue = allHeaders.Substring(startPos);
            int endPos = cookieValue.IndexOf(";");
            cookieValue = cookieValue.Substring(0, endPos);

            return cookieValue;
        }

        private string getRT()
        {
            getBadooAsyncRT("search/");
            return badooData.RT;
        }


        private string getImageUrl(string htmlData)
        {
            string imageUrl = "";
            int startPos = htmlData.IndexOf("src=") + 5;
            imageUrl = htmlData.Substring(startPos);
            int endPos = imageUrl.IndexOf("\"");
            imageUrl = imageUrl.Substring(0, endPos);
            return imageUrl;
        }


        private void printUserList()
        {
            //if (refreshCheck.Checked == false) return;
            badooUsersMutex.WaitOne();
            if (badooData.reloadUsers == true)
            {
                badooData.chatUsers.Clear();
                badooData.chatUsersHelper.Clear();
                usersListBox.Items.Clear();
                getUserList();
                badooData.reloadUsers = false;
            }
            int i=0;
            foreach (var currentBadooUser in badooData.chatUsers)
            {
                if (badooData.chatUsersHelper.Count > i)
                {

                }
                else
                {
                    badooData.chatUsersHelper.Add(currentBadooUser.Key);
                }
                i++;
            }
            badooUsersMutex.ReleaseMutex();

            badooUsersMutex.WaitOne();
            i = 0;
            foreach (var currentUserId in badooData.chatUsersHelper)
            {
                badooUser currentBadooUser = badooData.chatUsers[currentUserId];
                string listItem = currentBadooUser.Name;
                listItem += " (";
                if (currentBadooUser.MessagesNew>0)
                {
                    listItem = "* " + listItem;
                }
                listItem += currentBadooUser.MessagesCount + " msgs";
                listItem += ")";

                if (currentBadooUser.Status == 0)
                {
                    listItem += " - OFFLINE";
                }
                if (usersListBox.Items.Count > i && usersListBox.Items[i] != null)
                {
                    usersListBox.Items[i] = listItem;
                }
                else
                {
                    usersListBox.Items.Add(listItem);
                }

                i++;
            }
            badooUsersMutex.ReleaseMutex();
        }

        private void printFavUserList()
        {
            //badooFavUsersMutex.WaitOne();
            //if (refreshCheck.Checked == false) return;
            //int preSelected = favListBox.SelectedIndex;
            //favListBox.Items.Clear();

            //foreach (var currentBadooUser in badooData.favUsers)
            //{
            //    string listItem = currentBadooUser.Value.Name;
            //    listItem += " (";
            //    if (currentBadooUser.Value.MessagesNew > 0)
            //    {
            //        listItem += currentBadooUser.Value.MessagesNew + " new / ";
            //    }
            //    listItem += currentBadooUser.Value.MessagesCount + " msgs";
            //    listItem += ")";
            //    if (currentBadooUser.Value.Status == 0)
            //    {
            //        listItem += " - OFFLINE";
            //    }
            //    favListBox.Items.Add(listItem);
            //}
            //if (favListBox.Items.Count >= preSelected)
            //{
            //    favListBox.SelectedIndex = preSelected;
            //}

            // -----
            badooFavUsersMutex.WaitOne();
            int i = 0;
            foreach (var currentBadooUser in badooData.favUsers)
            {
                if (badooData.favUsersHelper.Count > i)
                {

                }
                else
                {
                    badooData.favUsersHelper.Add(currentBadooUser.Key);
                }
                i++;
            }
            badooFavUsersMutex.ReleaseMutex();

            badooFavUsersMutex.WaitOne();
            i = 0;
            foreach (var currentUserId in badooData.favUsersHelper)
            {
                badooUser currentBadooUser = badooData.favUsers[currentUserId];
                string listItem = currentBadooUser.Name;
                listItem += " (";
                if (currentBadooUser.MessagesNew > 0)
                {
                    listItem += currentBadooUser.MessagesNew + " new / ";
                }
                listItem += currentBadooUser.MessagesCount + " msgs";
                listItem += ")";

                if (currentBadooUser.Status == 0)
                {
                    listItem += " - OFFLINE";
                }
                if (favListBox.Items.Count > i && favListBox.Items[i] != null)
                {
                    favListBox.Items[i] = listItem;
                }
                else
                {
                    favListBox.Items.Add(listItem);
                }

                i++;
            }
            badooFavUsersMutex.ReleaseMutex();
        }


        private void usersListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedIndex = usersListBox.SelectedIndex;
            if (selectedIndex < 0) selectedIndex = 0;
            badooUser currentUser = (badooUser)badooData.chatUsers.ElementAt(selectedIndex).Value;
            string currentImageUrl = currentUser.Image;
            userImage.LoadAsync(currentImageUrl);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            getRT();
        }

        private string getBadooResponse(string requestUrl)
        {
            string responseString = "";
            HttpWebRequest request = getBadooRequest(requestUrl);
            request.CookieContainer = new CookieContainer();
            request.CookieContainer.Add(new Uri("http://badoo.com"),
                new Cookie("s1", badooData.cookieS1));
            HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            using (StreamReader reader = new StreamReader(response.GetResponseStream()))
            {
                responseString = reader.ReadToEnd();
                response.Close();
            }
            return responseString;
        }

        public static HttpWebRequest getBadooRequest(string requestUrl)
        {
            string url = "http://badoo.com/" + requestUrl;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.CookieContainer = new CookieContainer();
            request.CookieContainer.Add(new Uri("http://badoo.com"),
            new Cookie("s1", badooData.cookieS1));
            return request;
        }

        public static void getBadooAsync(string requestUrl)
        {
            HttpWebRequest request = getBadooRequest(requestUrl);
            ThreadPool.QueueUserWorkItem(o =>
            {
                try
                {
                    HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                    response.Close();
                    badooData.messagesSent += 1;
                }
                catch { }
            });
        }
        private void getBadooAsyncRT(string requestUrl)
        {
            HttpWebRequest request = getBadooRequest(requestUrl);
            ThreadPool.QueueUserWorkItem(o =>
            {
                try
                {
                    HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                    using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                    {
                        string RT = reader.ReadToEnd();
                        response.Close();
                        RT = RT.Substring(100);
                        int startPos = RT.IndexOf("\"rt\":") + 6;
                        RT = RT.Substring(startPos);
                        int endPos = RT.IndexOf("\"");
                        RT = RT.Substring(0, endPos);
                        Debug.WriteLine(RT);
                        Debug.WriteLine("xxxxxxxxxxx");
                        badooData.RT = RT;
                        badooData.cookieS1 = getCookie("s1",response);
                        Debug.WriteLine("S1: "+badooData.cookieS1);
                    }
                }
                catch { }
            });
        }

        private void getBadooAsyncMessage(string requestUrl)
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
                        if (dict["errno"] != 0)
                        {
                            //logOut();
                            return;
                        }
                        string messageHtml = dict["data"]["messages"]["html"].ToString();
                        if (dict["data"]["info"]["status"].ToString() == "online")
                        {
                            badooData.chatUsers[badooData.selectedUser].Status = 1;
                        }
                        else
                        {
                            badooData.chatUsers[badooData.selectedUser].Status = 0;
                        }

                        string formattedMessage = "Messages with " + dict["data"]["info"]["name"]+Environment.NewLine;
                        while (messageHtml.IndexOf("chat_msg") != -1)
                        {
                            int startPos;
                            int endPos;

                            startPos = messageHtml.IndexOf("chat_msg_author\">") + 17;
                            messageHtml = messageHtml.Substring(startPos);
                            endPos = messageHtml.IndexOf("</");
                            string author = messageHtml.Substring(0, endPos).Trim();

                            startPos = messageHtml.IndexOf("chat_msg_date\">") + 15;
                            messageHtml = messageHtml.Substring(startPos);
                            endPos = messageHtml.IndexOf("</");
                            string date = messageHtml.Substring(0, endPos).Trim().Trim('—');

                            startPos = messageHtml.IndexOf("message_text\">") + 14;
                            messageHtml = messageHtml.Substring(startPos);
                            endPos = messageHtml.IndexOf("</");
                            string messageText = messageHtml.Substring(0, endPos).Trim();

                            formattedMessage += date + " " + author + " : " + messageText + Environment.NewLine;
                        }

                        if (badooData.chatUsers[badooData.selectedUser].Status == 0)
                        {
                            formattedMessage += badooData.chatUsers[badooData.selectedUser].Name + " is OFFLINE" + Environment.NewLine;
                        }
                        actualMessagesMutex.WaitOne();
                        badooData.actualMessages = formattedMessage;
                        actualMessagesMutex.ReleaseMutex();
                    }
                }
                catch{}
        }

        private void badooDrawMessages()
        {
            actualMessagesMutex.WaitOne();
            textBox1.Text = badooData.actualMessages;
            actualMessagesMutex.ReleaseMutex();
            textBox1.SelectionStart = textBox1.Text.Length;
            textBox1.ScrollToCaret();
        }

        private HttpWebResponse getBadooLoginHeaders(string requestUrl,string userName, string password, string RT)
        {
            string url = "http://badoo.com/" + requestUrl;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            string postData = "email="+HttpUtility.UrlEncode(userName);
            postData += "&password="+HttpUtility.UrlEncode(password);
            postData += "&remember=1";
            postData += "&rt="+RT;
            postData += "&post= ";
            byte[] data = Encoding.UTF8.GetBytes(postData);

            request.Method = "POST";
            request.Host = "badoo.com";
            request.ContentType = "application/x-www-form-urlencoded";
            request.UserAgent = "Mozilla/5.0 (Windows NT 5.1) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/27.0.1453.110 Safari/537.36";
            request.ContentLength = data.Length;
            request.KeepAlive = true;
            var sp = request.ServicePoint;
            var prop = sp.GetType().GetProperty("HttpBehaviour", BindingFlags.Instance | BindingFlags.NonPublic);
            prop.SetValue(sp, (byte)0, null);
            sp.Expect100Continue = false;
            request.CookieContainer = new CookieContainer();
            request.CookieContainer.Add(new Uri("http://badoo.com"),
                new Cookie("s1", badooData.cookieS1));
            request.AllowAutoRedirect = false;
            
            using (Stream stream = request.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }
            HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            return response;
        }

        private void loadMessagesText()
        {   
            if (badooData.RT == "") return;
            ThreadPool.QueueUserWorkItem(o =>
            {
                getBadooAsyncMessage("connections/ws-load-user.phtml?ws=1&rt=" + badooData.RT + "&contact_user_id=" + badooData.selectedUser.ToString());
            });
        }


        private void sendMessage(string messageText)
        {
            if (badooData.RT == "") getRT();
            string requestUrl = "connections/ws-post.phtml?ws=1&rt=" + badooData.RT + "&contact_user_id=" + badooData.selectedUser + "&message=" + messageText;
            getBadooAsync(requestUrl);
            loadMessagesText();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (badooData.selectedUser != 0 && newMsgTxtBox.Text != "")
            {
                sendMessage(newMsgTxtBox.Text);
                newMsgTxtBox.Text = "";
                statusBar.Text = "Message sent";
                loadMessagesText();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (badooData.RT == "") return;
            if (loginButton.Enabled==true && badooData.logged==1) logInPost();
            if (badooData.logged == 1)
            {
                getUserList();
                loadMessagesText();
                if (refreshCheck.Checked == true && globalTimer == 0)
                {

                    if (tabControl1.SelectedIndex == 0)
                    {
                        getUserList();
                    }
                    else if (tabControl1.SelectedIndex == 1)
                    {
                        /*
                        getUserListFav();
                        getFavDetailed();
                        */
                        getFavDetailed();
                    }
                    updateUserListMore();
                }
            }
            globalTimer++;
            if (globalTimer == 3) globalTimer = 0;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadSettings();
            LoadPreMessages();
            getRT();
            System.Threading.Thread.Sleep(3000);
            doLogin("jk.man@seznam.cz", "231091", badooData.RT);
            /*
            if (badooData.cookieS1 == "")
            {
                //logOut();
                return;
            }
            else
            {
                logInPost();
            }            
            if (badooData.RT == "")
            {
                getRT();
            }
            getUserList();
            statusBar.Text = "User list loaded";
            getRT();
            statusBar.Text = "RT loaded - ready";
            updateDebugInfo();
             * */
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void pagesCount_ValueChanged(object sender, EventArgs e)
        {
            badooData.reloadUsers = true;
            statusBar.Text = "Users being reloaded";
        }

        private void usersListBox_DoubleClick(object sender, EventArgs e)
        {
            if (usersListBox.SelectedIndex >= 0)
            {
                badooData.selectedUser = badooData.chatUsers.ElementAt(usersListBox.SelectedIndex).Value.Id;
                loadMessagesText();
                getUserList();
            }
        }
        private void updateDebugInfo()
        {
            RTLabel.Text = "RT: " + badooData.RT;
            S1Label.Text = "S1: " + badooData.cookieS1;
            MSLabel.Text = "MS: " + badooData.messagesSent.ToString();
        }

        private void SaveSettings()
        {
            ModifyRegistry myRegistry = new ModifyRegistry();
            myRegistry.Write("RT", badooData.RT);
            myRegistry.Write("S1", badooData.cookieS1);
            myRegistry.Write("PC", pagesCount.Value.ToString());
            myRegistry.Write("MS", badooData.messagesSent.ToString());
            myRegistry.Write("RL", (refreshCheck.Checked==true)?"1":"0");
        }
        private void LoadSettings()
        {
            ModifyRegistry myRegistry = new ModifyRegistry();
            /*if (myRegistry.Read("RT") != null)
                badooData.RT = myRegistry.Read("RT");*/
            /*if (myRegistry.Read("S1") != null)
                badooData.cookieS1 = myRegistry.Read("S1");*/
            if (myRegistry.Read("PC") != null)
                pagesCount.Value = Int32.Parse(myRegistry.Read("PC"));
            if (myRegistry.Read("MS") != null)
            badooData.messagesSent = Int32.Parse(myRegistry.Read("MS"));
            if (myRegistry.Read("RL") == "1")
                refreshCheck.Checked = true;
            else
                refreshCheck.Checked = false;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveSettings();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            Form2 loginForm = new Form2();
            Debug.WriteLine("RT: "+badooData.RT);

            if (loginForm.ShowDialog() == DialogResult.OK)
            {
                if (loginForm.userName != "" && loginForm.password!="")
                {
                    statusBar.Text = "Trying to log in";
                    doLogin(loginForm.userName, loginForm.password, badooData.RT);
                }
            }
        }
        private void doLogin(string userName, string password, string RT)
        {
            ThreadPool.QueueUserWorkItem(o =>
            {
                Debug.WriteLine("RT: " + RT);
                HttpWebResponse loginResponse = getBadooLoginHeaders("signin", userName, password, badooData.RT);

                string responseString = "";
                using (StreamReader reader = new StreamReader(loginResponse.GetResponseStream()))
                {
                    responseString = reader.ReadToEnd();
                    loginResponse.Close();
                }
                Debug.WriteLine(getCookie("s1", loginResponse));
                if (responseString.IndexOf("signInForm") > 0)
                {
                    MessageBox.Show("Log in failed");
                    return;
                }
                badooData.cookieS1 = getCookie("s1", loginResponse);

                getRT();
                getUserList();
                badooData.logged = 1;
                //logInPost();
            });
        }

        private void logoutButton_Click(object sender, EventArgs e)
        {
            logOut();
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void notifyIcon1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Activated(object sender, EventArgs e)
        {
            timerForTrayIcon.Enabled = true;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            activated = !activated;
            timerForTrayIcon.Enabled = false;
        }

        private void Form1_VisibleChanged(object sender, EventArgs e)
        {
           
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Form3 searcher = new Form3();
            searcher.Show();
        }

        private void redrawCurrentUserInfo()
        {
            badooUsersMutex.WaitOne();
            badooFavUsersMutex.WaitOne();
            if (badooData.chatUsers.ContainsKey(badooData.selectedUser))
            {
                currentName.Text = badooData.chatUsers[badooData.selectedUser].Name;
                currentAge.Text = badooData.chatUsers[badooData.selectedUser].Age.ToString() + " years";
                currentTown.Text = badooData.chatUsers[badooData.selectedUser].Town;
            }
            else if (badooData.favUsers.ContainsKey(badooData.selectedUser))
            {
                currentName.Text = badooData.favUsers[badooData.selectedUser].Name;
                currentAge.Text = badooData.favUsers[badooData.selectedUser].Age.ToString() + " years";
                currentTown.Text = badooData.favUsers[badooData.selectedUser].Town;
            }
            badooFavUsersMutex.ReleaseMutex();
            badooUsersMutex.ReleaseMutex();
        }

        private void timerUpdateInfo_Tick(object sender, EventArgs e)
        {
            updateDebugInfo();
            int newMessagesTotal = badooData.newMessagesTotal;
            if (badooData.newMessagesTotal > badooData.newMessagesTotalOld)
            {
                notifyIcon1.BalloonTipText = newMessagesTotal + " new";
                notifyIcon1.ShowBalloonTip(1);
            }
            badooData.newMessagesTotalOld = badooData.newMessagesTotal;
            this.Text = ((newMessagesTotal > 0) ? "(" + newMessagesTotal + ") " : "") + "BadooChat";
            redrawCurrentUserInfo();
            badooDrawMessages();
            if (refreshCheck.Checked == true)
            {
                
                if (tabControl1.SelectedIndex == 0)
                {
                    printUserList();
                }
                else if (tabControl1.SelectedIndex == 1)
                {
                    printFavUserList();
                }
            }
        }

        private void userImage_Click(object sender, EventArgs e)
        {

        }

        private void userImage_DoubleClick(object sender, EventArgs e)
        {
            if (getListUserId()!=-1)
            {
                openUserWeb(getListUserId());
            }
        }
        private void openUserWeb(int userId)
        {
            string href = "http://badoo.com/0" + userId + "/";
            Process.Start(href);
        }

        private void showCurrentPhoto_Click(object sender, EventArgs e)
        {
            try
            {
                string currentImageUrl = badooData.chatUsers[badooData.selectedUser].Image;
                userImage.LoadAsync(currentImageUrl);
            }
            catch { }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 1)
            {
                getUserListFav();
                getFavDetailed();
                printFavUserList();
            }
        }

        private void usersListBox_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            try
            {
                if (usersListBox.SelectedIndex >= 0)
                {
                    string currentImageUrl = badooData.chatUsers.ElementAt(usersListBox.SelectedIndex).Value.Image;
                    userImage.LoadAsync(currentImageUrl);
                }
            }
            catch { }
        }

        private void favListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (favListBox.SelectedIndex >= 0)
                {
                    string currentImageUrl = badooData.favUsers.ElementAt(favListBox.SelectedIndex).Value.Image;
                    userImage.LoadAsync(currentImageUrl);
                }
            }
            catch { }
        }

        private void usersListBox_DoubleClick_1(object sender, EventArgs e)
        {
            if (usersListBox.SelectedIndex >= 0)
            {
                badooData.selectedUser = badooData.chatUsers.ElementAt(usersListBox.SelectedIndex).Key;
                loadMessagesText();
            }
            newMsgTxtBox.Focus();
        }

        private void favListBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (favListBox.SelectedIndex >= 0)
            {
                badooData.selectedUser = badooData.favUsers.ElementAt(favListBox.SelectedIndex).Key;
                loadMessagesText();
            }
        }

        private int getListUserId()
        {
            if (tabControl1.SelectedIndex == 0)
            {
                if (usersListBox.SelectedIndex >= 0)
                {
                    return badooData.chatUsers.ElementAt(usersListBox.SelectedIndex).Key;
                }
            }
            else if (tabControl1.SelectedIndex == 1)
            {
                if (favListBox.SelectedIndex >= 0)
                {
                    return badooData.favUsers.ElementAt(favListBox.SelectedIndex).Key;
                }
            }

            return -1;
        }

        private void chatUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (getListUserId() != -1)
            {
                badooData.selectedUser = getListUserId();
                loadMessagesText();
            }
        }

        private void openInBrowserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (getListUserId() != -1)
            {
                openUserWeb(getListUserId());
            }
        }

        private void addToFavouritesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int userId = getListUserId();
            if (userId != -1)
            {
                ThreadPool.QueueUserWorkItem(o =>
                {
                    getBadooResponse("ws/contacts-move.phtml?cloud=2&user_id=" + userId + "&folder_type=Favorites&in_messenger=1&action=move_to&burl=1370896798879&reload=0&rt=" + badooData.RT);
                });
            }
        }

        private void removeFromListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int userId = getListUserId();
            if (userId != -1)
            {
                ThreadPool.QueueUserWorkItem(o =>
                {
                    getBadooResponse("ws/contacts-move.phtml?action=clear_history&burl=1370896798879&rt=" + badooData.RT + "&users_ids[" + userId + "]=1");
                    if (badooData.chatUsers.ContainsKey(userId))
                    {
                        badooData.reloadUsers = true;
                    }
                    if (badooData.favUsers.ContainsKey(userId))
                    {
                        badooData.favUsers.Remove(userId);
                    }
                });
            }
        }
        private void LoadPreMessages()
        {
            try
            {
                string[] readText = File.ReadAllLines("premessages.txt");
                foreach (string radek in readText)
                {
                    badooData.preMessages.Add(radek);
                    preMessage.Items.Add(radek.Substring(0,(radek.Length<=20)?radek.Length:20));
                }
            }
            catch { }
            preMessage.SelectedIndex = 0;
            preMessage.Text = "Pre-messages";
        }

        private void preMessage_SelectedIndexChanged(object sender, EventArgs e)
        {
            int userId = getListUserId();
            int preMessageIndex=preMessage.SelectedIndex;
            if (userId != -1 && preMessageIndex > 0)
            {
                ThreadPool.QueueUserWorkItem(o =>
                {
                    string preMessageString = badooData.preMessages.ElementAt(preMessageIndex-1);
                    string requestUrl = "connections/ws-post.phtml?ws=1&rt=" + badooData.RT + "&contact_user_id=" + userId + "&message=" + preMessageString;
                    getBadooResponse(requestUrl);
                });
                statusBar.Text = "Pre-message sent";
            }
            contextMenuStrip1.Close();
        }

        private void downloadAllPhotosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int userId = getListUserId();
            if (userId != -1)
            {
                try
                {
                    ThreadPool.QueueUserWorkItem(o =>
                    {
                        string badooUserName="";
                        if (badooData.chatUsers.ContainsKey(userId))
                        {
                            badooUserName=badooData.chatUsers[userId].Name;
                        }
                        else if (badooData.favUsers.ContainsKey(userId))
                        {
                            badooUserName = badooData.favUsers[userId].Name;
                        }
                        if (!Directory.Exists("photos"))
                        {
                            Directory.CreateDirectory("photos");
                        }
                        string photoPath = "photos\\" + badooUserName + "-" + userId.ToString();
                        if (!Directory.Exists(photoPath))
                        {
                            Directory.CreateDirectory(photoPath);
                        }


                        string jsonResult = getBadooResponse("ws/popup.photo-view.phtml?user_id=" + userId + "&ws=1&rt=" + badooData.RT);
                        var jss = new JavaScriptSerializer();
                        var dict = jss.Deserialize<dynamic>(jsonResult);
                        Process.Start(AppDomain.CurrentDomain.BaseDirectory+photoPath);
                        foreach (var photo in dict["vars"]["photos"])
                        {
                            try
                            {
                                string photoUrl = photo["url"].ToString();
                                using (WebClient Client = new WebClient())
                                {
                                    Client.DownloadFile(photoUrl, photoPath + "\\" + photo["id"].ToString() + ".jpg");
                                }
                            }
                            catch { }
                        }
                    });
                }
                catch { }
            }
        }

        private void blockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int userId = getListUserId();
            if (userId != -1)
            {
                ThreadPool.QueueUserWorkItem(o =>
                {
                    getBadooResponse("ws/contacts-move.phtml?cloud=1&user_id="+badooData.RT+"&folder_type=Deleted&place=messenger&action=move_to&burl=1370906447853&reload=0&rt="+badooData.RT);
                    if (badooData.chatUsers.ContainsKey(userId))
                    {
                        badooData.reloadUsers = true;
                    }
                    if (badooData.favUsers.ContainsKey(userId))
                    {
                        badooData.favUsers.Remove(userId);
                    }
                });
            }
        }

        private void preMessage_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            HelpForm helpform = new HelpForm();
            helpform.Show();
        }

        private void showApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (this.Visible == true)
                {
                    timerForTrayIcon.Enabled = true;
                    this.Hide();
                }

                if (this.Visible == false && activated == false)
                {
                    timerForTrayIcon.Enabled = true;
                    this.Show();
                    this.WindowState = FormWindowState.Normal;
                }
            }
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HelpForm helpform = new HelpForm();
            helpform.Show();
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
