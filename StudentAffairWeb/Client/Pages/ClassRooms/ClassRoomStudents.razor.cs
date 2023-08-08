namespace StudentAffairWeb.Client.Pages.ClassRooms;

partial class ClassRoomStudents
{   
        public string? searchText { get; set; }

        List<ClassRoomStudent>? classRoomStudents;

        protected override async Task OnInitializedAsync()
        {
            classRoomStudents = await GetClassRoomStudents();
            searchText = "";
        }

        protected override async Task OnParametersSetAsync() => classRoomStudents = await GetClassRoomStudents();

        public async Task<List<ClassRoomStudent>?> GetClassRoomStudents() => await _client.GetFromJsonAsync<List<ClassRoomStudent>>("api/ClassRoomStudent");

        public void AddClassRoomStudent() => navigationManager.NavigateTo("AddClassRoomStudent");

        public async void Delete(Guid? id)
        {
            await _client.DeleteAsync($"api/ClassRoomStudent/{id.ToString()}");
            classRoomStudents = await GetClassRoomStudents();
            StateHasChanged();
        }
        public void Update(Guid? id)
        {
            navigationManager.NavigateTo($"EditClassRoomStudent/{id.ToString()}");
            StateHasChanged();
        }
        public async Task Search()
        {
            classRoomStudents = await _client.GetFromJsonAsync<List<ClassRoomStudent>>($"api/ClassRoomStudent/Search/{searchText}");
            StateHasChanged();
        }

}