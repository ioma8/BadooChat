using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    class badooData
    {
        public static string myUserId;
        public static string cookieS1="";
        public static string RT="";
        public static string username = "";
        public static string password = "";
        public static int logged = 0;
        public static Dictionary<int, badooUser> chatUsers = new Dictionary<int, badooUser>();
        public static Dictionary<int, badooUser> favUsers = new Dictionary<int, badooUser>();
        public static int selectedUser = 0;
        public static int messagesSent = 0;
        public static int newMessagesTotal = 0;
        public static int newMessagesTotalOld = 0;
        public static string actualMessages = "";
        public static bool reloadUsers = false;
        public static List<string> preMessages = new List<string>();
        public static List<int> chatUsersHelper = new List<int>();
        public static List<int> favUsersHelper = new List<int>();
    }
    class badooUser
    {
        public string Image="";
        public string Name="";
        public int MessagesCount=0;
        public int MessagesNew=0;
        public int Id=0;
        public int Age=0;
        public string Town="";
        public string MessagesText="";
        public string Href = "";
        public int Status = 1; // 1 = online; 0 = offline
    }
    class badooSearch
    {
        public static Dictionary<int, badooUser> searchedUsers = new Dictionary<int, badooUser>();
    }
}
