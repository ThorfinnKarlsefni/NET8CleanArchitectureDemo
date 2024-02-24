namespace LogisticsManagementSystem.Domain;

public class RandomAvatar
{
    private List<string> Avatars = new List<string> {
        "http://avatar.xhwt56.com/faMo564dybuiIN01eIR5TBQXjZVG.avif",
        "http://avatar.xhwt56.com/ogrwRJqXMXSGHuGIC3JQ52HOdLpyME.avif",
        "http://avatar.xhwt56.com/f3564ef33373939b024fb791f21ec37b.avif",
        "http://avatar.xhwt56.com/d2880bf06e15a7fa3b17e9db32a7050b.avif",
        "http://avatar.xhwt56.com/a65afc41e66633b16cb5d4bedc90dac0.avif",
        "http://avatar.xhwt56.com/038df35e8e85ed94cebfdb4cbcd991b0.avif",
        "http://avatar.xhwt56.com/5eaf95c210fa76978d58fec9b9d9e8ba.avif",
        "http://avatar.xhwt56.com/0c5e0cca27663206031fb7360c4680bf.avif"
    };

    public string GetRandomAvatar()
    {
        var random = new Random();
        int randomIndex = random.Next(0, Avatars.Count);
        return Avatars[randomIndex];
    }
}
