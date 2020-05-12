<Codebox Title="Checkable">
    <Description>
        <p>
            <code>CheckableTag</code> works like a Checkbox, click it to toggle the checked state. it is an absolute controlled component and has no uncontrolled mode so you must always define <code>Checked</code> to alter the <code>Checked</code> state.
        </p>
    </Description>
    <Demo>
        @foreach (var tag in tagsData)
        {
            <CheckableTag Checked="checkedTags.Contains(tag)" OnChange="(e) => handleChange(tag, e)">
                @tag
            </CheckableTag>
        }
    </Demo>
</Codebox>
@code{
    List<string> tagsData = new List<string>(new string[] { "Movies", "Books", "Music", "Sports" });
    List<string> checkedTags = new List<string>(new string[] { "Books" });

    private void handleChange(string tag, bool checkedd)
    {
        if (checkedd)
        {
            checkedTags.Add(tag);
        }
        else
        {
            checkedTags.Remove(tag);
        }
        System.Diagnostics.Debug.WriteLine(String.Format("checked tags: [{0}]", string.Join(", ", checkedTags)));
    }
}