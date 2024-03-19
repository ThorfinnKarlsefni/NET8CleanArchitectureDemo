namespace LogisticsManagementSystem.Domain;

public class RandomAvatar
{
    public string url = "http://124.222.5.145:8080";
    private List<string> Avatars = new List<string> { };

    public RandomAvatar()
    {
        Avatars = new List<string> {
        $"{url}/faMo564dybuiIN01eIR5TBQXjZVG.avif",
        $"{url}/ogrwRJqXMXSGHuGIC3JQ52HOdLpyME.avif",
        $"{url}/f3564ef33373939b024fb791f21ec37b.avif",
        $"{url}/d2880bf06e15a7fa3b17e9db32a7050b.avif",
        $"{url}/a65afc41e66633b16cb5d4bedc90dac0.avif",
        $"{url}/038df35e8e85ed94cebfdb4cbcd991b0.avif",
        $"{url}/5eaf95c210fa76978d58fec9b9d9e8ba.avif",
        $"{url}/0c5e0cca27663206031fb7360c4680bf.avif"
        };
    }
    public string GetRandomAvatar()
    {
        var random = new Random();
        int randomIndex = random.Next(0, Avatars.Count);
        return Avatars[randomIndex];
    }
}
