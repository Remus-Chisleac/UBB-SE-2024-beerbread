namespace app.src;

public partial class PlaylistsPage : ContentPage
{
    public PlaylistsPage()
    {
        InitializeComponent();
    }



    private void AddButtonTapped(object sender, EventArgs e)
    {
        DisplayAlert("Password Error", "Must be at least 8 characters", "OK");
        return;
    }

    private void DetailsDelete(object sender, EventArgs e)
    {
        DisplayAlert("Password Error", "Aici o sa fie pagina de delete.", "OK");
        return;
    }

    private void BackButtonTapped(object sender, EventArgs e)
    {
        //it should go back one page or to the home page 
        //TO BE IMPLEMENTED
        src.Main_page.MainPage mainpage = new src.Main_page.MainPage();
        Navigation.PushAsync(mainpage);
    }



    private void PlaylistDetailPageButton(object sender, EventArgs e)
    {
        //it should go to the specific playlist' details page
        //TO BE IMPLEMENTED
        DisplayAlert("Password Error", "Aici o sa fie pagina de detalii playlist.", "OK");
        return;

    }



    private void LibraryPageButtonClicked(object sender, EventArgs e)
    {
        //it should go back to the main page
        //TO BE IMPLEMENTED
        PlaylistsPage playlistsPage = new PlaylistsPage();
        Navigation.PushAsync(playlistsPage);
    }

    private void SearchPageButtonClicked(object sender, EventArgs e)
    {
        //it should go back to the explore page
        //TO BE IMPLEMENTED

        DisplayAlert("Password Error", "Aici o sa fie pagina de search.", "OK");
        return;

    }

    private void HomePageButtonClicked(object sender, EventArgs e)
    {
        //it should go back to the main page
        //TO BE IMPLEMENTED

        DisplayAlert("Password Error", "Aici o sa fie pagina de home.", "OK");
        return;

    }

}
