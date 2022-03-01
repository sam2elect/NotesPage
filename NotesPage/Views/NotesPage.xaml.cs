protected override async void OnAppearing()
{
    base.OnAppearing();

    // Retrieve all the notes from the database, and set them as the
    // data source for the CollectionView.
    collectionView.ItemsSource = await App.Database.GetNotesAsync();
}

async void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
{
    if (e.CurrentSelection != null)
    {
        // Navigate to the NoteEntryPage, passing the ID as a query parameter.
        Note note = (Note)e.CurrentSelection.FirstOrDefault();
        await Shell.Current.GoToAsync($"{nameof(NoteEntryPage)}?{nameof(NoteEntryPage.ItemId)}={note.ID.ToString()}");
    }
}