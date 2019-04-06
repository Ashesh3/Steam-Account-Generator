using SteamAccCreator.File;
using SteamAccCreator.Web;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SteamAccCreator.Gui
{
    public class AccountCreator
    {
        #region Animals
        private static readonly string[] Animals = new[]
        {
            "Aardvark", "Albatross", "Alligator", "Alpaca",
            "Ant", "Anteater", "Antelope", "Ape", "Armadillo",
            "Donkey", "Baboon", "Badger", "Barracuda", "Bat",
            "Bear", "Beaver", "Bee", "Bison", "Boar", "Buffalo",
            "Butterfly", "Camel", "Capybara", "Caribou",
            "Cassowary", "Cat", "Caterpillar", "Cattle",
            "Chamois", "Cheetah", "Chicken", "Chimpanzee",
            "Chinchilla", "Chough", "Clam", "Cobra",
            "Cockroach", "Cod", "Cormorant", "Coyote", "Crab",
            "Crane", "Crocodile", "Crow", "Curlew", "Deer",
            "Dinosaur", "Dog", "Dogfish", "Dolphin", "Dotterel",
            "Dove", "Dragonfly", "Duck", "Dugong", "Dunlin",
            "Eagle", "Echidna", "Eel", "Eland", "Elephant",
            "Elk", "Emu", "Falcon", "Ferret", "Finch", "Fish",
            "Flamingo", "Fly", "Fox", "Frog", "Gaur", "Gazelle",
            "Gerbil", "Giraffe", "Gnat", "Gnu", "Goat", "Goldfinch",
            "Goldfish", "Goose", "Gorilla", "Goshawk", "Grasshopper",
            "Grouse", "Guanaco", "Gull", "Hamster", "Hare", "Hawk",
            "Hedgehog", "Heron", "Herring", "Hippopotamus", "Hornet",
            "Horse", "Human", "Hummingbird", "Hyena", "Ibex", "Ibis",
            "Jackal", "Jaguar", "Jay", "Jellyfish", "Kangaroo",
            "Kingfisher", "Koala", "Kookabura", "Kouprey", "Kudu",
            "Lapwing", "Lark", "Lemur", "Leopard", "Lion", "Llama",
            "Lobster", "Locust", "Loris", "Louse", "Lyrebird",
            "Magpie", "Mallard", "Manatee", "Mandrill", "Mantis",
            "Marten", "Meerkat", "Mink", "Mole", "Mongoose", "Monkey",
            "Moose", "Mosquito", "Mouse", "Mule", "Narwhal", "Newt",
            "Nightingale", "Octopus", "Okapi", "Opossum", "Oryx",
            "Ostrich", "Otter", "Owl", "Oyster", "Panther", "Parrot",
            "Partridge", "Peafowl", "Pelican", "Penguin", "Pheasant",
            "Pig", "Pigeon", "Pony", "Porcupine", "Porpoise", "Quail",
            "Quelea", "Quetzal", "Rabbit", "Raccoon", "Rail", "Ram",
            "Rat", "Raven", "RedDeer", "RedPanda", "Reindeer",
            "Rhinoceros", "Rook", "Salamander", "Salmon", "SandDollar",
            "Sandpiper", "Sardine", "Scorpion", "Seahorse", "Seal",
            "Shark", "Sheep", "Shrew", "Skunk", "Snail", "Snake",
            "Sparrow", "Spider", "Spoonbill", "Squid", "Squirrel",
            "Starling", "Stingray", "Stinkbug", "Stork", "Swallow",
            "Swan", "Tapir", "Tarsier", "Termite", "Tiger", "Toad",
            "Trout", "Turkey", "Turtle", "Viper", "Vulture", "Wallaby",
            "Walrus", "Wasp", "Weasel", "Whale", "Wildcat", "Wolf",
            "Wolverine", "Wombat", "Woodcock", "Woodpecker", "Worm",
            "Wren", "Yak", "Zebra"
        };
        #endregion
        #region Adj
        private static readonly string[] Adj = new[]
        {
            "aback", "abaft", "abandoned", "abashed", "aberrant",
            "abhorrent", "abiding", "abject", "ablaze", "able",
            "abnormal", "aboard", "aboriginal", "abortive",
            "abounding", "abrasive", "abrupt", "absent", "absorbed",
            "absorbing", "abstracted", "absurd", "abundant",
            "abusive", "acceptable", "accessible", "accidental",
            "accurate", "acid", "acidic", "acoustic", "acrid",
            "actually", "ad", "hoc", "adamant", "adaptable",
            "addicted", "adhesive", "adjoining", "adorable",
            "adventurous", "afraid", "aggressive", "agonizing",
            "agreeable", "ahead", "ajar", "alcoholic", "alert",
            "alike", "alive", "alleged", "alluring", "aloof", "amazing",
            "ambiguous", "ambitious", "amuck", "amused", "amusing",
            "ancient", "angry", "animated", "annoyed", "annoying",
            "anxious", "apathetic", "aquatic", "aromatic", "arrogant",
            "ashamed", "aspiring", "assorted", "astonishing",
            "attractive", "auspicious", "automatic", "available",
            "average", "awake", "aware", "awesome", "awful", "axiomatic",
            "bad", "barbarous", "bashful", "bawdy", "beautiful",
            "befitting", "belligerent", "beneficial", "bent", "berserk",
            "best", "better", "bewildered", "big", "billowy", "bitesized",
            "bitter", "bizarre", "black", "blackandwhite", "bloody",
            "blue", "blueeyed", "blushing", "boiling", "boorish", "bored",
            "boring", "bouncy", "boundless", "brainy", "brash", "brave",
            "brawny", "breakable", "breezy", "brief", "bright", "bright",
            "broad", "broken", "brown", "bumpy", "burly", "bustling", "busy",
            "cagey", "calculating", "callous", "calm", "capable",
            "capricious", "careful", "careless", "caring", "cautious",
            "ceaseless", "certain", "changeable", "charming", "cheap",
            "cheerful", "chemical", "chief", "childlike", "chilly",
            "chivalrous", "chubby", "chunky", "clammy", "classy", "clean",
            "clear", "clever", "cloistered", "cloudy", "closed", "clumsy",
            "cluttered", "coherent", "cold", "colorful", "colossal",
            "combative", "comfortable", "common", "complete", "complex",
            "concerned", "condemned", "confused", "conscious", "cooing",
            "cool", "cooperative", "coordinated", "courageous", "cowardly",
            "crabby", "craven", "crazy", "creepy", "crooked", "crowded",
            "cruel", "cuddly", "cultured", "cumbersome", "curious", "curly",
            "curved", "curvy", "cut", "cute", "cute", "cynical", "daffy",
            "daily", "damaged", "damaging", "damp", "dangerous", "dapper",
            "dark", "dashing", "dazzling", "dead", "deadpan", "deafening",
            "dear", "debonair", "decisive", "decorous", "deep", "deeply",
            "defeated", "defective", "defiant", "delicate", "delicious",
            "delightful", "demonic", "delirious", "dependent", "depressed",
            "deranged", "descriptive", "deserted", "detailed", "determined",
            "devilish", "didactic", "different", "difficult", "diligent",
            "direful", "dirty", "disagreeable", "disastrous", "discreet",
            "disgusted", "disgusting", "disillusioned", "dispensable",
            "distinct", "disturbed", "divergent", "dizzy", "domineering",
            "doubtful", "drab", "draconian", "dramatic", "dreary", "drunk",
            "dry", "dull", "dusty", "dynamic", "dysfunctional", "eager",
            "early", "earsplitting", "earthy", "easy", "eatable",
            "economic", "educated", "efficacious", "efficient", "eight",
            "elastic", "elated", "elderly", "electric", "elegant", "elfin",
            "elite", "embarrassed", "eminent", "empty", "enchanted",
            "enchanting", "encouraging", "endurable", "energetic",
            "enormous", "entertaining", "enthusiastic", "envious",
            "equable", "equal", "erect", "erratic", "ethereal",
            "evanescent", "evasive", "even", "excellent", "excited",
            "exciting", "exclusive", "exotic", "expensive", "extralarge",
            "extrasmall", "exuberant", "exultant", "fabulous", "faded",
            "faint", "fair", "faithful", "fallacious", "false", "familiar",
            "famous", "fanatical", "fancy", "fantastic", "far", "farflung",
            "fascinated", "fast", "fat", "faulty", "fearful", "fearless",
            "feeble", "feigned", "female", "fertile", "festive", "few",
            "fierce", "filthy", "fine", "finicky", "first", "five",
            "fixed", "flagrant", "flaky", "flashy", "flat", "flawless",
            "flimsy", "flippant", "flowery", "fluffy", "fluttering",
            "foamy", "foolish", "foregoing", "forgetful", "fortunate",
            "four", "frail", "fragile", "frantic", "free", "freezing",
            "frequent", "fresh", "fretful", "friendly", "frightened",
            "frightening", "full", "fumbling", "functional", "funny",
            "furry", "furtive", "future", "futuristic", "fuzzy", "gabby",
            "gainful", "gamy", "gaping", "garrulous", "gaudy", "general",
            "gentle", "giant", "giddy", "gifted", "gigantic", "glamorous",
            "gleaming", "glib", "glistening", "glorious", "glossy", "godly",
            "good", "goofy", "gorgeous", "graceful", "grandiose", "grateful",
            "gratis", "gray", "greasy", "great", "greedy", "green", "grey",
            "grieving", "groovy", "grotesque", "grouchy", "grubby", "gruesome",
            "grumpy", "guarded", "guiltless", "gullible", "gusty", "guttural",
            "habitual", "half", "hallowed", "halting", "handsome", "handsomely",
            "handy", "hanging", "hapless", "happy", "hard", "hardtofind",
            "harmonious", "harsh", "hateful", "heady", "healthy",
            "heartbreaking", "heavenly", "heavy", "hellish", "helpful",
            "helpless", "hentai", "hesitant", "hideous", "high", "highfalutin",
            "highpitched", "hilarious", "hissing", "historical", "holistic",
            "hollow", "homeless", "homely", "honorable", "horrible", "hospitable",
            "hot", "huge", "hulking", "humdrum", "humorous", "hungry", "hurried",
            "hurt", "hushed", "husky", "hypnotic", "hysterical", "icky", "icy",
            "idiotic", "ignorant", "ill", "illegal", "illfated", "illinformed",
            "illustrious", "imaginary", "immense", "imminent", "impartial",
            "imperfect", "impolite", "important", "imported", "impossible",
            "incandescent", "incompetent", "inconclusive", "industrious",
            "incredible", "inexpensive", "infamous", "innate", "innocent",
            "inquisitive", "insidious", "instinctive", "intelligent",
            "interesting", "internal", "invincible", "irate", "irritating", "itchy",
            "jaded", "jagged", "jazzy", "jealous", "jittery", "jobless", "jolly",
            "joyous", "judicious", "juicy", "jumbled", "jumpy", "juvenile", "kaput",
            "keen", "kind", "kindhearted", "kindly", "knotty", "knowing",
            "knowledgeable", "known", "labored", "lackadaisical", "lacking", "lame",
            "lamentable", "languid", "large", "last", "late", "laughable", "lavish",
            "lazy", "lean", "learned", "left", "legal", "lethal", "level", "lewd",
            "light", "like", "likeable", "limping", "literate", "little", "lively",
            "lively", "living", "lonely", "long", "longing", "longterm", "loose",
            "lopsided", "loud", "loutish", "lovely", "loving", "low", "lowly",
            "lucky", "ludicrous", "lumpy", "lush", "luxuriant", "lying", "lyrical",
            "macabre", "macho", "maddening", "madly", "magenta", "magical",
            "magnificent", "majestic", "makeshift", "male", "malicious", "mammoth",
            "maniacal", "many", "marked", "massive", "married", "marvelous",
            "material", "materialistic", "mature", "mean", "measly", "meaty",
            "medical", "meek", "mellow", "melodic", "melted", "merciful", "mere",
            "messy", "mighty", "military", "milky", "mindless", "miniature",
            "minor", "miscreant", "misty", "mixed", "moaning", "modern", "moldy",
            "momentous", "motionless", "mountainous", "muddled", "mundane", "murky",
            "mushy", "mute", "mysterious", "naive", "nappy", "narrow", "nasty",
            "natural", "naughty", "nauseating", "near", "neat", "nebulous",
            "necessary", "needless", "needy", "neighborly", "nervous", "new", "next",
            "nice", "nifty", "nimble", "nine", "nippy", "noiseless", "noisy",
            "nonchalant", "nondescript", "nonstop", "normal", "nostalgic", "nosy",
            "noxious", "null", "numberless", "numerous", "nutritious", "nutty",
            "oafish", "obedient", "obeisant", "obese", "obnoxious", "obscene",
            "obsequious", "observant", "obsolete", "obtainable", "oceanic", "odd",
            "offbeat", "old", "oldfashioned", "omniscient", "one", "onerous", "open",
            "opposite", "optimal", "orange", "ordinary", "organic", "ossified",
            "outgoing", "outrageous", "outstanding", "oval", "overconfident",
            "overjoyed", "overrated", "overt", "overwrought", "painful", "painstaking",
            "pale", "paltry", "panicky", "panoramic", "parallel", "parched",
            "parsimonious", "past", "pastoral", "pathetic", "peaceful", "penitent",
            "perfect", "periodic", "permissible", "perpetual", "petite", "petite",
            "phobic", "physical", "picayune", "pink", "piquant", "placid", "plain",
            "plant", "plastic", "plausible", "pleasant", "plucky", "pointless",
            "poised", "polite", "political", "poor", "possessive", "possible",
            "powerful", "precious", "premium", "present", "pretty", "previous",
            "pricey", "prickly", "private", "probable", "productive", "profuse",
            "protective", "proud", "psychedelic", "psychotic", "public", "puffy",
            "pumped", "puny", "purple", "purring", "pushy", "puzzled", "puzzling",
            "quack", "quaint", "quarrelsome", "questionable", "quick", "quickest",
            "quiet", "quirky", "quixotic", "quizzical", "rabid", "racial", "ragged",
            "rainy", "rambunctious", "rampant", "rapid", "rare", "raspy", "ratty",
            "ready", "real", "rebel", "receptive", "recondite", "red", "redundant",
            "reflective", "regular", "relieved", "remarkable", "reminiscent",
            "repulsive", "resolute", "resonant", "responsible", "rhetorical", "rich",
            "right", "righteous", "rightful", "rigid", "ripe", "ritzy", "roasted",
            "robust", "romantic", "roomy", "rotten", "rough", "round", "royal",
            "ruddy", "rude", "rural", "rustic", "ruthless", "sable", "sad", "safe",
            "salty", "same", "sassy", "satisfying", "savory", "scandalous", "scarce",
            "scared", "scary", "scattered", "scientific", "scintillating", "scrawny",
            "screeching", "second", "secondhand", "secret", "secretive", "sedate",
            "seemly", "selective", "selfish", "separate", "serious", "shaggy",
            "shaky", "shallow", "sharp", "shiny", "shivering", "shocking", "short",
            "shrill", "shut", "shy", "sick", "silent", "silent", "silky", "silly",
            "simple", "simplistic", "sincere", "six", "skillful", "skinny", "sleepy",
            "slim", "slimy", "slippery", "sloppy", "slow", "small", "smart", "smelly",
            "smiling", "smoggy", "smooth", "sneaky", "snobbish", "snotty", "soft",
            "soggy", "solid", "somber", "sophisticated", "sordid", "sore", "sore",
            "sour", "sparkling", "special", "spectacular", "spicy", "spiffy", "spiky",
            "spiritual", "spiteful", "splendid", "spooky", "spotless", "spotted",
            "spotty", "spurious", "squalid", "square", "squealing", "squeamish",
            "staking", "stale", "standing", "statuesque", "steadfast", "steady",
            "steep", "stereotyped", "sticky", "stiff", "stimulating", "stingy", "stormy",
            "straight", "strange", "striped", "strong", "stupendous", "stupid", "sturdy",
            "subdued", "subsequent", "substantial", "successful", "succinct", "sudden",
            "sulky", "super", "superb", "superficial", "supreme", "swanky", "sweet",
            "sweltering", "swift", "symptomatic", "synonymous", "taboo", "tacit",
            "tacky", "talented", "tall", "tame", "tan", "tangible", "tangy", "tart",
            "tasteful", "tasteless", "tasty", "tawdry", "tearful", "tedious", "teeny",
            "teenytiny", "telling", "temporary", "ten", "tender", "tense", "tense",
            "tenuous", "terrible", "terrific", "tested", "testy", "thankful",
            "therapeutic", "thick", "thin", "thinkable", "third", "thirsty",
            "thoughtful", "thoughtless", "threatening", "three", "thundering", "tidy",
            "tight", "tightfisted", "tiny", "tired", "tiresome", "toothsome", "torpid",
            "tough", "towering", "tranquil", "trashy", "tremendous", "tricky", "trite",
            "troubled", "truculent", "true", "truthful", "two", "typical", "ubiquitous",
            "ugliest", "ugly", "ultra", "unable", "unaccountable", "unadvised", "unarmed",
            "unbecoming", "unbiased", "uncovered", "understood", "undesirable", "unequal",
            "unequaled", "uneven", "unhealthy", "uninterested", "unique", "unkempt",
            "unknown", "unnatural", "unruly", "unsightly", "unsuitable", "untidy",
            "unused", "unusual", "unwieldy", "unwritten", "upbeat", "uppity", "upset",
            "uptight", "used", "useful", "useless", "utopian", "utter", "uttermost",
            "vacuous", "vagabond", "vague", "valuable", "various", "vast", "vengeful",
            "venomous", "verdant", "versed", "victorious", "vigorous", "violent", "violet",
            "vivacious", "voiceless", "volatile", "voracious", "vulgar", "wacky", "waggish",
            "waiting", "wakeful", "wandering", "wanting", "warlike", "warm", "wary",
            "wasteful", "watery", "weak", "wealthy", "weary", "wellgroomed", "wellmade",
            "welloff", "welltodo", "wet", "whimsical", "whispering", "white", "whole",
            "wholesale", "wicked", "wide", "wideeyed", "wiggly", "wild", "willing",
            "windy", "wiry", "wise", "wistful", "witty", "woebegone", "womanly",
            "wonderful", "wooden", "woozy", "workable", "worried", "worthless", "wrathful",
            "wretched", "wrong", "wry", "xenophobic", "yellow", "yielding", "young",
            "youthful", "yummy", "zany", "zealous", "zesty", "zippy", "zonked"
        };
        #endregion

        private readonly HttpHandler _httpHandler;
        private readonly FileManager _fileManager = new FileManager();
        private readonly MailHandler _mailHandler = new MailHandler();
        public readonly MainForm _mainForm;

        public readonly Models.Configuration Config;
        private string Mail
        {
            get => Config.Mail.Value;
            set => Config.Mail.Value = value;
        }
        public string Login
        {
            get => Config.Login.Value;
            set => Config.Login.Value = value;
        }
        public string Password
        {
            get => Config.Password.Value;
            set => Config.Password.Value = value;
        }
        private IEnumerable<Models.GameInfo> AddThisGames
            => (Config.Games.AddGames) ? Config.Games.GamesToAdd : new Models.GameInfo[0];

        private long SteamId = 0;
        private int GamesNotAdded = 0;
        private string Status;
        private Web.Captcha.CaptchaSolution CaptchaSolved;

        private readonly string EnteredLogin;
        private readonly int TableIndex;

        public AccountCreator(MainForm mainForm, Models.Configuration config)
        {
            Logger.Trace("Creating account: init...");
            CaptchaSolved = new Web.Captcha.CaptchaSolution(false, "Something went wrong...", config.Captcha);

            Status = "Init...";
            _mainForm = mainForm;

            Config = config;
            if (Config.Login.Random)
                Config.Login.Value = "Init...";
            if (Config.Password.Random)
                Config.Password.Value = "Init...";
            if (Config.Mail.Random)
                Config.Mail.Value = "Init...";

            EnteredLogin = (Config.Login.Random) ? string.Empty : Login;

            TableIndex = _mainForm.AddToTable(Mail, Login, Password, SteamId, Status);

            _httpHandler = new HttpHandler(_mainForm, config.Proxy);
            Logger.Trace("Creating account: init done");
        }

        public async void Run()
        {
            Logger.Trace("Creating account: starting...");
            if (Config.Login.Random)
            {
                if (Config.Login.Neat)
                    Login = Adj.RandomElement().ToTitleCase() +
                        Adj.RandomElement().ToTitleCase() +
                        Adj.RandomElement().ToTitleCase() +
                        Animals.RandomElement();
                else
                    Login = Utility.GetRandomString(12);
            }
            else
                Login = EnteredLogin + TableIndex;

            UpdateStatusFull();

            if (Config.Password.Random)
            {
                if (Config.Password.Neat)
                {
                    string neatOffline()
                        => Adj.RandomElement().ToTitleCase() +
                            Adj.RandomElement().ToTitleCase() +
                            Adj.RandomElement().ToTitleCase() +
                            Utility.GetRandomString(2) + Utility.GetRandomNumber(100, 1000);

                    Password = Utility.GetRandomString(24) + Utility.GetRandomNumber(100, 1000);

                    try
                    {
                        var _client21 = new RestSharp.RestClient("https://makemeapassword.ligos.net");
                        var request21 = new RestSharp.RestRequest("api/v1/passphrase/plain?pc=1&wc=3&sp=n&maxCh=30", RestSharp.Method.GET);
                        var queryResult1 = _client21.Execute(request21);
                        var neatPasw = queryResult1.Content.Trim();
                        if (Regex.IsMatch(neatPasw, @"automatically\swithin\s(\d+)\shour", RegexOptions.IgnoreCase))
                            Password = neatOffline();
                        else
                            Password = neatPasw + Utility.GetRandomString(2) + Utility.GetRandomNumber(100, 1000);
                    }
                    catch (Exception ex)
                    {
                        Logger.Error("Neat password error", ex);
                        Password = neatOffline();
                    }
                }
                else
                    Password = Utility.GetRandomString(24) + Utility.GetRandomNumber(100, 1000);
            }

            UpdateStatusFull();

            if (Config.Mail.Random)
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

                var _cli = new RestSharp.RestClient(MailHandler.MailboxUri);

                var _reqProvider = new RestSharp.RestRequest(RestSharp.Method.GET);
                var providerResult = _cli.Execute(_reqProvider);

                string Provider = providerResult.Content;
                if (!Provider.StartsWith("@"))
                {
                    Logger.Warn($"Creating account: temp. mail service error: {Provider}");
                    UpdateStatus("No email service... Try again (later)?...");
                    return;
                }

                var mailCheck = new RestSharp.RestRequest(RestSharp.Method.GET);
                mailCheck.AddParameter("alias", Login);
                var mailCheckResult = _cli.Execute(mailCheck);

                if (mailCheckResult.Content != "ok")
                {
                    Logger.Warn($"Creating account: Something went wrong with temp. mail service...\nResponse: {mailCheckResult.Content}\n---------\nHTTP Status-Code: {mailCheckResult.StatusCode}\n====== END ======");
                    UpdateStatus($"Something went wrong... HTTP Status-Code: {mailCheckResult.StatusCode}");
                    return;
                }

                Mail = (Login + Provider).ToLower();
            }

            UpdateStatusFull();

            if (Config.Captcha.Enabled)
                UpdateStatus("Solving Captcha...");
            else
                UpdateStatus("Creating Account..");

            StartCreation();

            bool verified;
            int tries = 5;
            do
            {
                VerifyMail();

                var bShouldRetry = false;
                verified = CheckIfMailIsVerified(ref bShouldRetry);
                if (!verified && !bShouldRetry)
                    tries--;

                Logger.Debug($"Creating account: mail verified = {verified}, should retry = {bShouldRetry}, tries left = {tries}");

                await Task.Delay(2000).ConfigureAwait(false);
            }
            while (!verified && tries > 0);

            if (verified)
            {
                FinishCreation();

                WriteAccountIntoFile();

                Logger.Debug("Creating account: DONE!");
                UpdateStatus($"Finished{(((Config.Games.AddGames) ? $" | Games skipped: {GamesNotAdded}" : ""))}");
            }
            else
            {
                Logger.Debug("Creating account: Error, email not verified.");
                UpdateStatus("No Email Received.. Try again!");
            }
        }

        private void StartCreation()
        {
            var success = false;

            do
            {
                if (Config.Captcha.Enabled)
                    UpdateStatus("Recognizing Captcha...");
                else
                    UpdateStatus("Waiting for captcha solution...");

                CaptchaSolved = ShowCaptchaDialog(_httpHandler, (s) => UpdateStatus(s), Config.Captcha);
                if (!CaptchaSolved.Solved)
                {
                    Logger.Warn($"Captcha solving: Error: {CaptchaSolved.Message}");

                    if (CaptchaSolved.RetryAvailable)
                    {
                        UpdateStatus($"{CaptchaSolved.Message} | Retrying...");
                        continue;
                    }

                    UpdateStatus(CaptchaSolved.Message);
                    return;
                }

                UpdateStatus("Creating Account...");
                var bShouldStop = false;
                success = _httpHandler.CreateAccount(Mail, CaptchaSolved, (s) => UpdateStatus(s), ref bShouldStop);

                if (bShouldStop)
                    return;
            }
            while (!success);
        }

        private void VerifyMail()
        {
            if (Config.Mail.Random)
                _mailHandler.ConfirmMail(Mail);
        }

        private bool CheckIfMailIsVerified(ref bool shouldRetry)
            => _httpHandler.CheckEmailVerified((s) => UpdateStatus(s), ref shouldRetry);

        private void FinishCreation()
        {
            var _status = "";
            while (!_httpHandler.CompleteSignup(Login, Password, (s) => UpdateStatus(_status = s), ref SteamId, ref GamesNotAdded, AddThisGames))
            {
                switch (_status)
                {
                    case Error.PASSWORD_UNSAFE:
                        Logger.Warn($"Creating account: {Error.PASSWORD_UNSAFE}");
                        Password = ShowUpdateInfoBox(_status);
                        UpdateStatusFull();
                        break;
                    case Error.ALIAS_UNAVAILABLE:
                        Logger.Warn($"Creating account: {Error.ALIAS_UNAVAILABLE}");
                        Login = ShowUpdateInfoBox(_status);
                        UpdateStatusFull();
                        break;
                    default:
                        return;
                }
            }
        }

        private void WriteAccountIntoFile()
        {
            if (Config.Output.Enabled)
            {
                UpdateStatus("Writing to file...");
                _fileManager.WriteIntoFile(Mail, Config.Output.WriteEmails, Login, Password, SteamId, Environment.ExpandEnvironmentVariables(Config.Output.Path), Config.Output.SaveType);
            }
        }

        public void UpdateStatusFull()
            => _mainForm.UpdateStatus(TableIndex, Mail, Login, Password, SteamId, Status);
        public void UpdateStatus(string status)
            => _mainForm.UpdateStatus(TableIndex, Status = status, SteamId);

        private string ShowUpdateInfoBox(string status)
        {
            var inputDialog = new InputDialog(status);
            var update = string.Empty;

            if (inputDialog.ShowDialog() == DialogResult.OK)
            {
                update = inputDialog.txtInfo.Text;
            }
            inputDialog.Dispose();
            return update;
        }

        private Web.Captcha.CaptchaSolution ShowCaptchaDialog(HttpHandler httpHandler, Action<string> updateStatus, Models.CaptchaSolvingConfig captchaConfig)
        {
            using (var captchaDialog = new CaptchaDialog(httpHandler, updateStatus, captchaConfig))
            {
                if (captchaConfig.Enabled)
                    return captchaDialog.Solution;
                else if (captchaDialog.ShowDialog() == DialogResult.OK)
                    return captchaDialog.Solution;
                else
                    return new Web.Captcha.CaptchaSolution(false, "Captcha not recognized!", captchaConfig);
            }
        }
    }
}
