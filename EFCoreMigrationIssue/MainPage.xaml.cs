using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using EFCoreMigrationIssue.Persistence;
using Xamarin.Forms;

namespace EFCoreMigrationIssue
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        private FooRepository fooRepository;

        public MainPage()
        {
            InitializeComponent();
            fooRepository = new FooRepository();
            RecordUri = new Command(() => AddFooToRepository(),
                canExecute: () => !string.IsNullOrEmpty(Uri));
            LoadFooList();
        }

        internal ObservableCollection<Foo> FooList { get; private set; }
        internal ICommand RecordUri { get; private set; }
        internal string Uri { get; set; }

        private void LoadFooList()
        {
            FooList = new ObservableCollection<Foo>(fooRepository.GetAll());
        }

        private void AddFooToRepository()
        {
            var foo = new Foo(Uri);
            fooRepository.Add(foo);
        }

    }
}
