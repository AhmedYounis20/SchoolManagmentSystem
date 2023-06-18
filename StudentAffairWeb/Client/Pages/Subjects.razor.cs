
namespace StudentAffairWeb.Client.Pages;

partial class Subjects
{
        public string searchText { get; set; }

        List<Subject>? subjects;

        protected override async Task OnInitializedAsync()
        {
            subjects = await GetSubjects();
            searchText = "";
        }

        protected override async Task OnParametersSetAsync() => subjects = await GetSubjects();

        public async Task<List<Subject>?> GetSubjects() =>  await _client.GetFromJsonAsync<List<Subject>>("api/Subject");
        
        public void AddSubject() => navigationManager.NavigateTo("AddSubject");

        public async void Delete(Guid? id)
        {
            await _client.DeleteAsync($"api/Subject/{id.ToString()}");
            subjects = await GetSubjects();
            StateHasChanged();
        }
        public void Update(Guid? id)
        {
            navigationManager.NavigateTo($"EditSubject/{id.ToString()}");
            StateHasChanged();
        }
        public async Task Search()
        {
            subjects = await _client.GetFromJsonAsync<List<Subject>>($"api/Subject/Search/{searchText}");
            StateHasChanged();
        }
    
}