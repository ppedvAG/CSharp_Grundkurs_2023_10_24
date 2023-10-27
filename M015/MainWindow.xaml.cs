using Fahrzeugpark;
using System.Collections.ObjectModel;
using System.Windows;

namespace M015;

public partial class MainWindow : Window
{
	public int Zaehler { get; set; }

	public ObservableCollection<Fahrzeug> Fahrzeuge { get; set; } = new();

	public MainWindow()
	{
		//View -> Toolbox
		//Zeigt verschiedene UI Komponenten

		//View -> Properties
		//Einstellungen von einzelnen UI Komponenten anzeigen

		//MainWindow.xaml: UI Code
		//-> Ausklappen: Backend Code (MainWindow.xaml.cs)
		InitializeComponent();
		DataContext = this;
	}

	private void Button_Click(object sender, RoutedEventArgs e)
	{
		//Event
		//2 Seiten: Entwicklerseite, Anwenderseite
		//Entwicklerseite legt fest, wann das Event gefeuert wird
		//Anwenderseite gibt den Code vor, der beim feuern des Events ausgeführt wird
		Zaehler++;
		TB.Text = Zaehler.ToString();
	}

	private void NeuesFahrzeug(object sender, RoutedEventArgs e)
	{
		Fahrzeuge.Add(Fahrzeug.GeneriereFahrzeug());
		LB.ItemsSource = null;
		LB.ItemsSource = Fahrzeuge;
	}

	private void LoescheFahrzeug(object sender, RoutedEventArgs e)
	{
		if (LB.SelectedIndex != -1)
			Fahrzeuge.RemoveAt(LB.SelectedIndex);
		LB.ItemsSource = null;
		LB.ItemsSource = Fahrzeuge;
	}

	private void LB_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
	{
		if (LB.ItemsSource != null)
			InfoText.Text = Fahrzeuge[LB.SelectedIndex].Info();
	}
}
