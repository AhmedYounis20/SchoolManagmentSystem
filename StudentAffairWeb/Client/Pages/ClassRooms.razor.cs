namespace StudentAffairWeb.Client.Pages;

partial class ClassRooms
{

        public string? searchText { get; set; }
        List<ClassRoom>? classRooms;

        protected override async Task OnInitializedAsync()
        {
            classRooms = await GetClassRooms();
            searchText = "";
        }

        protected override async Task OnParametersSetAsync()=> classRooms = await GetClassRooms();

        public async Task<List<ClassRoom>?> GetClassRooms() => await _client.GetFromJsonAsync<List<ClassRoom>>("api/ClassRoom");

        public void AddClassRoom() => navigationManager.NavigateTo("AddClassRoom");

        public async void Delete(Guid? id)
        {
            await _client.DeleteAsync($"api/ClassRoom/{id.ToString()}");
            classRooms = await GetClassRooms();
            StateHasChanged();
        }
        public void Update(Guid? id)
        {
            navigationManager.NavigateTo($"EditClassRoom/{id.ToString()}");
            StateHasChanged();
        }
        public async Task Search()
        {
            classRooms = await _client.GetFromJsonAsync<List<ClassRoom>>($"api/ClassRoom/Search/{searchText}");
            StateHasChanged();
        }
}