using System.Collections.ObjectModel;
using TODO.Models;

namespace TODO
{
    public partial class MainPage : ContentPage
    {
        ObservableCollection<TodoItem> todoItems;
        TodoItem selectedItem;

        public MainPage()
        {
            InitializeComponent();

            todoItems = new ObservableCollection<TodoItem>();
            todoListView.ItemsSource = todoItems;
        }

        // ADD
        private void OnAddClicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(titleEntry.Text))
            {
                todoItems.Add(new TodoItem
                {
                    Title = titleEntry.Text,
                    Details = detailsEditor.Text
                });

                ClearFields();
            }
        }

        // SELECT ITEM
        private void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem is TodoItem item)
            {
                selectedItem = item;
                titleEntry.Text = item.Title;
                detailsEditor.Text = item.Details;
            }
        }

        // UPDATE
        private void OnUpdateClicked(object sender, EventArgs e)
        {
            if (selectedItem != null)
            {
                selectedItem.Title = titleEntry.Text;
                selectedItem.Details = detailsEditor.Text;

                // Refresh ListView
                todoListView.ItemsSource = null;
                todoListView.ItemsSource = todoItems;

                ClearFields();
            }
        }

        // DELETE
        private void OnDeleteClicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            var item = button?.CommandParameter as TodoItem;

            if (item != null)
            {
                todoItems.Remove(item);
            }
        }

        private void ClearFields()
        {
            titleEntry.Text = string.Empty;
            detailsEditor.Text = string.Empty;
            selectedItem = null;
            todoListView.SelectedItem = null;
        }
    }
}