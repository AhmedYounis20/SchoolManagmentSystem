namespace StudentAffairWeb.Client.Pages;

public partial class AddSubject
{
    [Parameter] public string id { get; set; }
    public Subject? _subject { get; set; } = new();
    protected override async Task OnParametersSetAsync()
    {
        if (!String.IsNullOrEmpty(id))
            _subject = await _client.GetFromJsonAsync<Subject>($"api/Subject/{id}");
        else
            _subject = new Subject();
    }

    public async void Submit()
    {
        if (_subject is not null)
        {
            if (String.IsNullOrEmpty(id))
            {
                await _client.PostAsJsonAsync<Subject>("api/Subject", _subject);
                navigationManager.NavigateTo("subjects");
            }
            else
            {
                await _client.PutAsJsonAsync<Subject>($"api/Subject", _subject);
                navigationManager.NavigateTo("subjects");
            }
        }
    }
}
