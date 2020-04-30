using System;
using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using Refit;
using XamarinGithubUser.Interface;
using System.Collections.Generic;
using XamarinGithubUser.Model;
using Android.Util;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json.Converters;
using System.Threading.Tasks;
using Android.Graphics;
using System.Net.Http;
using System.Net;

namespace XamarinGithubUser
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        IGitHubApi gitHubApi;
        List<User> users = new List<User>();
        List<String> user_names = new List<String>();
        IListAdapter ListAdapter;
        List<Owner> owners = new List<Owner>();
        List<String> owner_names = new List<String>();

        Button btn_get_data;
        ListView lst_users;
        Button btn_get_repos;
        ImageView img_avatar;
        

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            Android.Support.V7.Widget.Toolbar toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);

            btn_get_data = FindViewById<Button>(Resource.Id.btn_get_data);
            lst_users = FindViewById<ListView>(Resource.Id.list_user);
            btn_get_repos = FindViewById<Button>(Resource.Id.btn_get_repo);
            img_avatar = FindViewById<ImageView>(Resource.Id.imageView1);

            try
            {
                btn_get_data.Click += Btn_get_data_Click;

                btn_get_repos.Click += Btn_get_repos_Click;

                JsonConvert.DefaultSettings = () => new JsonSerializerSettings()
                {
                    ContractResolver = new CamelCasePropertyNamesContractResolver(),
                    Converters = { new StringEnumConverter() }
                };

                gitHubApi = RestService.For<IGitHubApi>("https://api.github.com");
                //var ireade = await gitHubApi.GetUser("ireade");


            }

            catch (Exception ex)
            {
                Log.Error("Ozioma See", ex.Message);
            }
        }

        private void Btn_get_repos_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            GetRepos();
            //GetOwners();
        }

        private async void GetOwners()
        {
            //throw new NotImplementedException();
            try
            {
                owner_names.Clear();
                UserRepo response = await gitHubApi.GetOwner();

                //var octocat = await gitHubApi.GetUser("octocat");
                //Console.WriteLine("octocat - " + octocat);
                //var repos_ = await gitHubApi.GetRepo("octocat/repos");
                //Console.WriteLine("repos - " + repos_);
                owners = response.items;

                foreach (Owner user in owners)
                {
                    /*
                    var img = user.avatar_url.ToString();
                    var imageBitmap = GetImageBitmapFromUrl(img);
                    img_avatar.SetImageBitmap(imageBitmap);
                    */
                    var repo = user.repos_url.ToString();
                    var avatar = user.avatar_url.ToString();
                    var nodeid = user.node_id.ToString();
                    var user_url = user.html_url.ToString();


                    owner_names.Add(user.ToString()+repo + System.Environment.NewLine + " Avatar: " + avatar + System.Environment.NewLine + " Node id: " + nodeid + System.Environment.NewLine + " User URL: " + user_url);
                }
                ListAdapter = new ArrayAdapter<String>(this, Android.Resource.Layout.SimpleListItem1, owner_names);
                lst_users.Adapter = ListAdapter;


            }
            catch (Exception ex)
            {
                Toast.MakeText(this, ex.StackTrace, ToastLength.Long).Show();

            }
        }

        private async void GetRepos()
        {
            try
            {
                user_names.Clear();
                ApiResponse response = await gitHubApi.GetUser();

                //var octocat = await gitHubApi.GetUser("octocat");
                //Console.WriteLine("octocat - " + octocat);
                //var repos_ = await gitHubApi.GetRepo("octocat/repos");
                //Console.WriteLine("repos - " + repos_);
                users = response.items;

                foreach (User user in users)
                {
                    /*
                    var img = user.avatar_url.ToString();
                    var imageBitmap = GetImageBitmapFromUrl(img);
                    img_avatar.SetImageBitmap(imageBitmap);
                    */
                    var repo = user.repos_url.ToString();
                    var avatar = user.avatar_url.ToString();
                    var score = user.score.ToString();
                    var user_url = user.html_url.ToString();


                    user_names.Add(repo + System.Environment.NewLine + " Avatar: " + avatar + System.Environment.NewLine + " Score: " + score + System.Environment.NewLine + " User URL: " + user_url);
                }
                ListAdapter = new ArrayAdapter<String>(this, Android.Resource.Layout.SimpleListItem1, user_names);
                lst_users.Adapter = ListAdapter;
                

            }
            catch (Exception ex)
            {
                Toast.MakeText(this, ex.StackTrace, ToastLength.Long).Show();

            }
        }

        private void Btn_get_data_Click(object sender, EventArgs e)
        {
            //Android.App.AlertDialog.Builder dialog = new Android.App.AlertDialog.Builder(this);
            //Android.App.AlertDialog alert = dialog.Create();
            ////alert.SetTitle("Github user list");
            //alert.SetMessage("Please wait..");
            //alert.SetButton("OK", (c, ev) =>
            //{
            //    // Ok button click task
                
            //});
            //alert.Show();
            getUsers();
        }
        /*
        private async Task<Bitmap> GetImageBitmapFromUrlAsync(string url)
        {
            Bitmap imageBitmap = null;

            using (var httpClient = new HttpClient())
            {
                var imageBytes = await httpClient.GetByteArrayAsync(url);
                if (imageBytes != null && imageBytes.Length > 0)
                {
                    imageBitmap = BitmapFactory.DecodeByteArray(imageBytes, 0, imageBytes.Length);
                }
            }

            return imageBitmap;
        }*/



        private async void getUsers()
        {
            try
            {
                user_names.Clear();
                ApiResponse response = await gitHubApi.GetUser();

                //var octocat = await gitHubApi.GetUser("octocat");
                //Console.WriteLine("octocat - " + octocat);
                //var repos_ = await gitHubApi.GetRepo("octocat/repos");
                //Console.WriteLine("repos - " + repos_);
                users = response.items;

                foreach (User user in users)
                {
                    /*
                    var img = user.avatar_url.ToString();
                    var imageBitmap = GetImageBitmapFromUrl(img);
                    img_avatar.SetImageBitmap(imageBitmap);
                    */
                    
                    user_names.Add(user.ToString());

                }
                ListAdapter = new ArrayAdapter<String>(this, Android.Resource.Layout.SimpleListItem1, user_names);
                lst_users.Adapter = ListAdapter;
                
            }
            catch (Exception ex)
            {
                Toast.MakeText(this, ex.StackTrace, ToastLength.Long).Show();

            }

        }
        private Bitmap GetImageBitmapFromUrl(string url)
        {
            Bitmap imageBitmap = null;

            using (var webClient = new WebClient())
            {
                var imageBytes = webClient.DownloadData(url);
                if (imageBytes != null && imageBytes.Length > 0)
                {
                    imageBitmap = BitmapFactory.DecodeByteArray(imageBytes, 0, imageBytes.Length);
                }
            }

            return imageBitmap;
        }
        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_main, menu);
            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            int id = item.ItemId;
            if (id == Resource.Id.action_settings)
            {
                return true;
            }

            return base.OnOptionsItemSelected(item);
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}

