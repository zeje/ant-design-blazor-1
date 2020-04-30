<Codebox Title="Autoset Font Size">
    <Description>
        <p>
            For an <code>Avatar</code> which contains text and the size of the text is bigger than the <code>Avatar</code>, the font size will be automatically adjusted according to the width of the <code>Avatar</code>.
        </p>
    </Description>
    <Demo>
        <div>
            <Avatar style="@($"background-color: {selectedUser.Value}; vertical-align: middle")" Size="Size.Large">
                @selectedUser.Key
            </Avatar>
            <Button Size="Size.Small" Label="Change User"
                    style="margin: 0 16px; vertical-align: middle;"
                    OnClick="ChangeUser"/>
        </div>
    </Demo>
</Codebox>

@code{
    private KeyValuePair<string, string> selectedUser = users[0];
    private int currentIndex;
    private static List<KeyValuePair<string, string>> users = new List<KeyValuePair<string, string>>()
{
            new KeyValuePair<string,string>("U", "#f56a00"),
            new KeyValuePair<string,string>("Lucy", "#7265e6"),
            new KeyValuePair<string,string>("Tom", "#ffbf00"),
            new KeyValuePair<string,string>("Edward", "#00a2ae"),
    };
    private void ChangeUser()
    {
        currentIndex++;
        if (currentIndex == users.Count)
            currentIndex = 0;

        selectedUser = users[currentIndex];
    }
}
