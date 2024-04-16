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

        Main_page.MainPage mainpage = new Main_page.MainPage();
        Navigation.PushAsync(mainpage);
    }



    private void PlaylistDetailPageButton(object sender, EventArgs e)
    {
        
        DisplayAlert("Error", "Aici o sa fie pagina de detalii playlist.", "OK");
        return;

    }


    private void LibraryPageButtonClicked(object sender, EventArgs e)
    {

        PlaylistsPage playlistsPage = new PlaylistsPage();
        Navigation.PushAsync(playlistsPage);
    }


    private void SearchPageButtonClicked(object sender, EventArgs e)
    {
        Main_page.MainPage mainpage = new src.Main_page.MainPage();
        Navigation.PushAsync(mainpage);

    }


    private void HomePageButtonClicked(object sender, EventArgs e)
    {
        Main_page.MainPage mainpage = new src.Main_page.MainPage();
        Navigation.PushAsync(mainpage);

    }

}
