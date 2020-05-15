@using System.Text.RegularExpressions;

<Codebox Title="Formatter">
    <Description>
        <p>
            Display value within it's situation with <code>formatter</code>, and we usually use <code>parser</code> at the same time.
</p>
    </Description>
    <Demo>
        <div>
            <InputNumber DefaultValue=1000 Formatter=Formatter1 Parser=Parser1 />
            <InputNumber DefaultValue=100 Min=0 Max=100 Formatter=Formatter2 Parser=Parser2 />
        </div>
    </Demo>
</Codebox>

@code{
    private string Formatter1(double value)
    {
        return "$ " + Regex.Replace(value.ToString(), @"\B(?=(\d{3})+(?!\d))", ",");
    }

    private double Parser1(string value)
    {
        double val = double.Parse(Regex.Replace(value, @"\$\s?|(,*)", ""));

        return val;
    }

    private string Formatter2(double value)
    {
        return value.ToString() + "%";
    }

    private double Parser2(string value)
    {
        return double.Parse(value.Replace("%", ""));
    }
}