namespace maui_quotes_for_programmers
{
  public partial class MainPage : ContentPage
  {
    readonly Random random = new Random();
    List<string> quotes = new List<string>();

    public MainPage()
    {
      InitializeComponent();
    }

    protected override async void OnAppearing()
    {
      base.OnAppearing();
      await LoadQuotes();
    }

    private void ButtonGenerateQuote_Clicked(object sender, EventArgs e)
    {
      // * Generate random gradient background
      var colorStart = System.Drawing.Color.FromArgb(
        random.Next(0, 256),
        random.Next(0, 256),
        random.Next(0, 256)
      );
      var colorEnd = System.Drawing.Color.FromArgb(
        random.Next(0, 256),
        random.Next(0, 256),
        random.Next(0, 256)
      );

      var colors = ColorUtility.ColorControls.GetColorGradient(colorStart, colorEnd, 6);

      float stopOffset = .0f;
      var stops = new GradientStopCollection();
      foreach (var c in colors)
      {
        stops.Add(new GradientStop(Color.FromArgb(c.Name), stopOffset));
        stopOffset += .2f;
      }

      var gradient = new LinearGradientBrush(stops, new Point(0, 0), new Point(1, 1));
      gridBackground.Background = gradient;

      // * Generate random quote
      int index = random.Next(quotes.Count);
      labelQuote.Text = quotes[index];
    }

    async Task LoadQuotes()
    {
      using var stream = await FileSystem.OpenAppPackageFileAsync("quotes.txt");
      using var reader = new StreamReader(stream);

      while (reader.Peek() != -1)
      {
        quotes.Add(reader.ReadLine());
      }
    }
  }
}
