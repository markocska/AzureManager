using Flowers.Data.ViewModel;
using Foundation;
using GalaSoft.MvvmLight.Helpers;

namespace Flowers
{
    [Register("AddCommentViewController")]
    public partial class AddCommentViewController
    {
        private Binding<string, string> _commentBinding;

        public FlowerViewModel Vm
        {
            get;
            private set;
        }

        public AddCommentViewController(FlowerViewModel flower)
        {
            Vm = flower;
        }

        public override void ViewDidLoad()
        {
            View = new UniversalView();
            base.ViewDidLoad();
            InitializeComponent();

            Title = "Add comment";

            _commentBinding = this.SetBinding(
                () => CommentText.Text)
                .UpdateSourceTrigger("Changed");

            SaveCommentButton.SetCommand("Clicked", Vm.SaveCommentCommand, _commentBinding);
        }
    }
}