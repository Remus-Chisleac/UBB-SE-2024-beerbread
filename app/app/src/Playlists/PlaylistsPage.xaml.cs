namespace app.src;

public partial class PlaylistsPage : ContentPage
{
    public PlaylistsPage()
    {
        InitializeComponent();
    }



    private void AddButtonTapped(object sender, EventArgs e)
    {
        DisplayAlert("Error", "Must be at least 8 characters", "OK");
        return;
    }

    private void DetailsDelete(object sender, EventArgs e)
    {
        DisplayAlert("Error", "Aici o sa fie pagina de delete.", "OK");
        return;
    }

    private void BackButtonTapped(object sender, EventArgs e)
    {
        Navigation.PopAsync();
    }



    private void PlaylistDetailPageButton(object sender, EventArgs e)
    {

        DisplayAlert("Error", "Aici o sa fie pagina de detalii playlist.", "OK");
        return;

    }


    private void LibraryPageButtonClicked(object sender, EventArgs e)
    {

    }


    private void SearchPageButtonClicked(object sender, EventArgs e)
    {
        Navigation.PopAsync();
    }


    private void HomePageButtonClicked(object sender, EventArgs e)
    {
        Navigation.PopAsync();
    }

}
