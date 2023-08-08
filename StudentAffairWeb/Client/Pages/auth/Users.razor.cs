using Microsoft.AspNetCore.Components.Web.Virtualization;
using Microsoft.JSInterop;

namespace StudentAffairWeb.Client.Pages.auth;

partial class Users
{
        public string? searchText { get; set; }

        List<User>? users=new();

        protected override async Task OnInitializedAsync()
        {
            users = await GetUsers();
            searchText = "";
        }

    protected override async Task OnParametersSetAsync() => users = await GetUsers();

    public async Task<List<User>?> GetUsers() => await _client.GetFromJsonAsync<List<User>>("api/User");

    public void AddUser() => navigationManager.NavigateTo("AddUser");

        public async void Delete(Guid? id)
        {
            await _client.DeleteAsync($"api/User/{id.ToString()}");
            users = await GetUsers();
            StateHasChanged();
        }
        public void Update(Guid? id)
        {
            navigationManager.NavigateTo($"EditUser/{id.ToString()}");
            StateHasChanged();
        }
        public async Task Search()
        {
            users = await _client.GetFromJsonAsync<List<User>>($"api/User/Search/{searchText}");
            StateHasChanged();
        }   
    
    private async Task DownloadProfilePic(User user)=> await Js.InvokeVoidAsync("downloadPic", user.ImagePath, user.Name);
    
}