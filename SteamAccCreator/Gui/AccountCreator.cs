using System;
using System.Windows.Forms;
using SteamAccCreator.File;
using SteamAccCreator.Web;
using System.Threading.Tasks;
using System.Globalization;
using System.Net;
using System.Text;
using System.Security.Cryptography;
using System.IO;
using System.Diagnostics;

namespace SteamAccCreator.Gui
{
    public class AccountCreator
    {
        private static readonly Random Random = new Random();

        private string _status;

        private readonly HttpHandler _httpHandler = new HttpHandler();
        private readonly FileManager _fileManager = new FileManager();
        private readonly MailHandler _mailHandler = new MailHandler();
        public readonly MainForm _mainForm;

        private string _alias, _pass, _mail = string.Empty;
        private long _steamId = 0;
        private bool _auto;
        private string[] _captcha;
        private readonly string _enteredAlias;
        private readonly int _index;

        public static int GetRandomNumber(int min, int max)
        {
            lock (Random) // synchronize
            {
                return Random.Next(min, max);
            }
        }
        public AccountCreator(MainForm mainForm, string mail, string alias, string pass, int index, bool auto)
        {
            _mainForm = mainForm;
            _mail = mail;
            _alias = alias;
            _enteredAlias = alias;
            _pass = pass;
            _index = index;
            _auto = auto;
        }
        private string GetMD5()
        {
            System.Security.Cryptography.MD5CryptoServiceProvider md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
            System.IO.FileStream stream = new System.IO.FileStream(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName, System.IO.FileMode.Open, System.IO.FileAccess.Read);

            md5.ComputeHash(stream);

            stream.Close();

            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            for (int i = 0; i < md5.Hash.Length; i++)
                sb.Append(md5.Hash[i].ToString("x2"));

            return sb.ToString().ToUpperInvariant();
        }

        public async void Run()
        {
            string[] animals = new string[] { "Aardvark", "Albatross", "Alligator", "Alpaca", "Ant", "Anteater", "Antelope", "Ape", "Armadillo", "Donkey", "Baboon", "Badger", "Barracuda", "Bat", "Bear", "Beaver", "Bee", "Bison", "Boar", "Buffalo", "Butterfly", "Camel", "Capybara", "Caribou", "Cassowary", "Cat", "Caterpillar", "Cattle", "Chamois", "Cheetah", "Chicken", "Chimpanzee", "Chinchilla", "Chough", "Clam", "Cobra", "Cockroach", "Cod", "Cormorant", "Coyote", "Crab", "Crane", "Crocodile", "Crow", "Curlew", "Deer", "Dinosaur", "Dog", "Dogfish", "Dolphin", "Dotterel", "Dove", "Dragonfly", "Duck", "Dugong", "Dunlin", "Eagle", "Echidna", "Eel", "Eland", "Elephant", "Elk", "Emu", "Falcon", "Ferret", "Finch", "Fish", "Flamingo", "Fly", "Fox", "Frog", "Gaur", "Gazelle", "Gerbil", "Giraffe", "Gnat", "Gnu", "Goat", "Goldfinch", "Goldfish", "Goose", "Gorilla", "Goshawk", "Grasshopper", "Grouse", "Guanaco", "Gull", "Hamster", "Hare", "Hawk", "Hedgehog", "Heron", "Herring", "Hippopotamus", "Hornet", "Horse", "Human", "Hummingbird", "Hyena", "Ibex", "Ibis", "Jackal", "Jaguar", "Jay", "Jellyfish", "Kangaroo", "Kingfisher", "Koala", "Kookabura", "Kouprey", "Kudu", "Lapwing", "Lark", "Lemur", "Leopard", "Lion", "Llama", "Lobster", "Locust", "Loris", "Louse", "Lyrebird", "Magpie", "Mallard", "Manatee", "Mandrill", "Mantis", "Marten", "Meerkat", "Mink", "Mole", "Mongoose", "Monkey", "Moose", "Mosquito", "Mouse", "Mule", "Narwhal", "Newt", "Nightingale", "Octopus", "Okapi", "Opossum", "Oryx", "Ostrich", "Otter", "Owl", "Oyster", "Panther", "Parrot", "Partridge", "Peafowl", "Pelican", "Penguin", "Pheasant", "Pig", "Pigeon", "Pony", "Porcupine", "Porpoise", "Quail", "Quelea", "Quetzal", "Rabbit", "Raccoon", "Rail", "Ram", "Rat", "Raven", "RedDeer", "RedPanda", "Reindeer", "Rhinoceros", "Rook", "Salamander", "Salmon", "SandDollar", "Sandpiper", "Sardine", "Scorpion", "Seahorse", "Seal", "Shark", "Sheep", "Shrew", "Skunk", "Snail", "Snake", "Sparrow", "Spider", "Spoonbill", "Squid", "Squirrel", "Starling", "Stingray", "Stinkbug", "Stork", "Swallow", "Swan", "Tapir", "Tarsier", "Termite", "Tiger", "Toad", "Trout", "Turkey", "Turtle", "Viper", "Vulture", "Wallaby", "Walrus", "Wasp", "Weasel", "Whale", "Wildcat", "Wolf", "Wolverine", "Wombat", "Woodcock", "Woodpecker", "Worm", "Wren", "Yak", "Zebra" };
            string[] adj = new string[] { "aback", "abaft", "abandoned", "abashed", "aberrant", "abhorrent", "abiding", "abject", "ablaze", "able", "abnormal", "aboard", "aboriginal", "abortive", "abounding", "abrasive", "abrupt", "absent", "absorbed", "absorbing", "abstracted", "absurd", "abundant", "abusive", "acceptable", "accessible", "accidental", "accurate", "acid", "acidic", "acoustic", "acrid", "actually", "ad", "hoc", "adamant", "adaptable", "addicted", "adhesive", "adjoining", "adorable", "adventurous", "afraid", "aggressive", "agonizing", "agreeable", "ahead", "ajar", "alcoholic", "alert", "alike", "alive", "alleged", "alluring", "aloof", "amazing", "ambiguous", "ambitious", "amuck", "amused", "amusing", "ancient", "angry", "animated", "annoyed", "annoying", "anxious", "apathetic", "aquatic", "aromatic", "arrogant", "ashamed", "aspiring", "assorted", "astonishing", "attractive", "auspicious", "automatic", "available", "average", "awake", "aware", "awesome", "awful", "axiomatic", "bad", "barbarous", "bashful", "bawdy", "beautiful", "befitting", "belligerent", "beneficial", "bent", "berserk", "best", "better", "bewildered", "big", "billowy", "bitesized", "bitter", "bizarre", "black", "blackandwhite", "bloody", "blue", "blueeyed", "blushing", "boiling", "boorish", "bored", "boring", "bouncy", "boundless", "brainy", "brash", "brave", "brawny", "breakable", "breezy", "brief", "bright", "bright", "broad", "broken", "brown", "bumpy", "burly", "bustling", "busy", "cagey", "calculating", "callous", "calm", "capable", "capricious", "careful", "careless", "caring", "cautious", "ceaseless", "certain", "changeable", "charming", "cheap", "cheerful", "chemical", "chief", "childlike", "chilly", "chivalrous", "chubby", "chunky", "clammy", "classy", "clean", "clear", "clever", "cloistered", "cloudy", "closed", "clumsy", "cluttered", "coherent", "cold", "colorful", "colossal", "combative", "comfortable", "common", "complete", "complex", "concerned", "condemned", "confused", "conscious", "cooing", "cool", "cooperative", "coordinated", "courageous", "cowardly", "crabby", "craven", "crazy", "creepy", "crooked", "crowded", "cruel", "cuddly", "cultured", "cumbersome", "curious", "curly", "curved", "curvy", "cut", "cute", "cute", "cynical", "daffy", "daily", "damaged", "damaging", "damp", "dangerous", "dapper", "dark", "dashing", "dazzling", "dead", "deadpan", "deafening", "dear", "debonair", "decisive", "decorous", "deep", "deeply", "defeated", "defective", "defiant", "delicate", "delicious", "delightful", "demonic", "delirious", "dependent", "depressed", "deranged", "descriptive", "deserted", "detailed", "determined", "devilish", "didactic", "different", "difficult", "diligent", "direful", "dirty", "disagreeable", "disastrous", "discreet", "disgusted", "disgusting", "disillusioned", "dispensable", "distinct", "disturbed", "divergent", "dizzy", "domineering", "doubtful", "drab", "draconian", "dramatic", "dreary", "drunk", "dry", "dull", "dusty", "dynamic", "dysfunctional", "eager", "early", "earsplitting", "earthy", "easy", "eatable", "economic", "educated", "efficacious", "efficient", "eight", "elastic", "elated", "elderly", "electric", "elegant", "elfin", "elite", "embarrassed", "eminent", "empty", "enchanted", "enchanting", "encouraging", "endurable", "energetic", "enormous", "entertaining", "enthusiastic", "envious", "equable", "equal", "erect", "erratic", "ethereal", "evanescent", "evasive", "even", "excellent", "excited", "exciting", "exclusive", "exotic", "expensive", "extralarge", "extrasmall", "exuberant", "exultant", "fabulous", "faded", "faint", "fair", "faithful", "fallacious", "false", "familiar", "famous", "fanatical", "fancy", "fantastic", "far", "farflung", "fascinated", "fast", "fat", "faulty", "fearful", "fearless", "feeble", "feigned", "female", "fertile", "festive", "few", "fierce", "filthy", "fine", "finicky", "first", "five", "fixed", "flagrant", "flaky", "flashy", "flat", "flawless", "flimsy", "flippant", "flowery", "fluffy", "fluttering", "foamy", "foolish", "foregoing", "forgetful", "fortunate", "four", "frail", "fragile", "frantic", "free", "freezing", "frequent", "fresh", "fretful", "friendly", "frightened", "frightening", "full", "fumbling", "functional", "funny", "furry", "furtive", "future", "futuristic", "fuzzy", "gabby", "gainful", "gamy", "gaping", "garrulous", "gaudy", "general", "gentle", "giant", "giddy", "gifted", "gigantic", "glamorous", "gleaming", "glib", "glistening", "glorious", "glossy", "godly", "good", "goofy", "gorgeous", "graceful", "grandiose", "grateful", "gratis", "gray", "greasy", "great", "greedy", "green", "grey", "grieving", "groovy", "grotesque", "grouchy", "grubby", "gruesome", "grumpy", "guarded", "guiltless", "gullible", "gusty", "guttural", "habitual", "half", "hallowed", "halting", "handsome", "handsomely", "handy", "hanging", "hapless", "happy", "hard", "hardtofind", "harmonious", "harsh", "hateful", "heady", "healthy", "heartbreaking", "heavenly", "heavy", "hellish", "helpful", "helpless", "hesitant", "hideous", "high", "highfalutin", "highpitched", "hilarious", "hissing", "historical", "holistic", "hollow", "homeless", "homely", "honorable", "horrible", "hospitable", "hot", "huge", "hulking", "humdrum", "humorous", "hungry", "hurried", "hurt", "hushed", "husky", "hypnotic", "hysterical", "icky", "icy", "idiotic", "ignorant", "ill", "illegal", "illfated", "illinformed", "illustrious", "imaginary", "immense", "imminent", "impartial", "imperfect", "impolite", "important", "imported", "impossible", "incandescent", "incompetent", "inconclusive", "industrious", "incredible", "inexpensive", "infamous", "innate", "innocent", "inquisitive", "insidious", "instinctive", "intelligent", "interesting", "internal", "invincible", "irate", "irritating", "itchy", "jaded", "jagged", "jazzy", "jealous", "jittery", "jobless", "jolly", "joyous", "judicious", "juicy", "jumbled", "jumpy", "juvenile", "kaput", "keen", "kind", "kindhearted", "kindly", "knotty", "knowing", "knowledgeable", "known", "labored", "lackadaisical", "lacking", "lame", "lamentable", "languid", "large", "last", "late", "laughable", "lavish", "lazy", "lean", "learned", "left", "legal", "lethal", "level", "lewd", "light", "like", "likeable", "limping", "literate", "little", "lively", "lively", "living", "lonely", "long", "longing", "longterm", "loose", "lopsided", "loud", "loutish", "lovely", "loving", "low", "lowly", "lucky", "ludicrous", "lumpy", "lush", "luxuriant", "lying", "lyrical", "macabre", "macho", "maddening", "madly", "magenta", "magical", "magnificent", "majestic", "makeshift", "male", "malicious", "mammoth", "maniacal", "many", "marked", "massive", "married", "marvelous", "material", "materialistic", "mature", "mean", "measly", "meaty", "medical", "meek", "mellow", "melodic", "melted", "merciful", "mere", "messy", "mighty", "military", "milky", "mindless", "miniature", "minor", "miscreant", "misty", "mixed", "moaning", "modern", "moldy", "momentous", "motionless", "mountainous", "muddled", "mundane", "murky", "mushy", "mute", "mysterious", "naive", "nappy", "narrow", "nasty", "natural", "naughty", "nauseating", "near", "neat", "nebulous", "necessary", "needless", "needy", "neighborly", "nervous", "new", "next", "nice", "nifty", "nimble", "nine", "nippy", "noiseless", "noisy", "nonchalant", "nondescript", "nonstop", "normal", "nostalgic", "nosy", "noxious", "null", "numberless", "numerous", "nutritious", "nutty", "oafish", "obedient", "obeisant", "obese", "obnoxious", "obscene", "obsequious", "observant", "obsolete", "obtainable", "oceanic", "odd", "offbeat", "old", "oldfashioned", "omniscient", "one", "onerous", "open", "opposite", "optimal", "orange", "ordinary", "organic", "ossified", "outgoing", "outrageous", "outstanding", "oval", "overconfident", "overjoyed", "overrated", "overt", "overwrought", "painful", "painstaking", "pale", "paltry", "panicky", "panoramic", "parallel", "parched", "parsimonious", "past", "pastoral", "pathetic", "peaceful", "penitent", "perfect", "periodic", "permissible", "perpetual", "petite", "petite", "phobic", "physical", "picayune", "pink", "piquant", "placid", "plain", "plant", "plastic", "plausible", "pleasant", "plucky", "pointless", "poised", "polite", "political", "poor", "possessive", "possible", "powerful", "precious", "premium", "present", "pretty", "previous", "pricey", "prickly", "private", "probable", "productive", "profuse", "protective", "proud", "psychedelic", "psychotic", "public", "puffy", "pumped", "puny", "purple", "purring", "pushy", "puzzled", "puzzling", "quack", "quaint", "quarrelsome", "questionable", "quick", "quickest", "quiet", "quirky", "quixotic", "quizzical", "rabid", "racial", "ragged", "rainy", "rambunctious", "rampant", "rapid", "rare", "raspy", "ratty", "ready", "real", "rebel", "receptive", "recondite", "red", "redundant", "reflective", "regular", "relieved", "remarkable", "reminiscent", "repulsive", "resolute", "resonant", "responsible", "rhetorical", "rich", "right", "righteous", "rightful", "rigid", "ripe", "ritzy", "roasted", "robust", "romantic", "roomy", "rotten", "rough", "round", "royal", "ruddy", "rude", "rural", "rustic", "ruthless", "sable", "sad", "safe", "salty", "same", "sassy", "satisfying", "savory", "scandalous", "scarce", "scared", "scary", "scattered", "scientific", "scintillating", "scrawny", "screeching", "second", "secondhand", "secret", "secretive", "sedate", "seemly", "selective", "selfish", "separate", "serious", "shaggy", "shaky", "shallow", "sharp", "shiny", "shivering", "shocking", "short", "shrill", "shut", "shy", "sick", "silent", "silent", "silky", "silly", "simple", "simplistic", "sincere", "six", "skillful", "skinny", "sleepy", "slim", "slimy", "slippery", "sloppy", "slow", "small", "smart", "smelly", "smiling", "smoggy", "smooth", "sneaky", "snobbish", "snotty", "soft", "soggy", "solid", "somber", "sophisticated", "sordid", "sore", "sore", "sour", "sparkling", "special", "spectacular", "spicy", "spiffy", "spiky", "spiritual", "spiteful", "splendid", "spooky", "spotless", "spotted", "spotty", "spurious", "squalid", "square", "squealing", "squeamish", "staking", "stale", "standing", "statuesque", "steadfast", "steady", "steep", "stereotyped", "sticky", "stiff", "stimulating", "stingy", "stormy", "straight", "strange", "striped", "strong", "stupendous", "stupid", "sturdy", "subdued", "subsequent", "substantial", "successful", "succinct", "sudden", "sulky", "super", "superb", "superficial", "supreme", "swanky", "sweet", "sweltering", "swift", "symptomatic", "synonymous", "taboo", "tacit", "tacky", "talented", "tall", "tame", "tan", "tangible", "tangy", "tart", "tasteful", "tasteless", "tasty", "tawdry", "tearful", "tedious", "teeny", "teenytiny", "telling", "temporary", "ten", "tender", "tense", "tense", "tenuous", "terrible", "terrific", "tested", "testy", "thankful", "therapeutic", "thick", "thin", "thinkable", "third", "thirsty", "thoughtful", "thoughtless", "threatening", "three", "thundering", "tidy", "tight", "tightfisted", "tiny", "tired", "tiresome", "toothsome", "torpid", "tough", "towering", "tranquil", "trashy", "tremendous", "tricky", "trite", "troubled", "truculent", "true", "truthful", "two", "typical", "ubiquitous", "ugliest", "ugly", "ultra", "unable", "unaccountable", "unadvised", "unarmed", "unbecoming", "unbiased", "uncovered", "understood", "undesirable", "unequal", "unequaled", "uneven", "unhealthy", "uninterested", "unique", "unkempt", "unknown", "unnatural", "unruly", "unsightly", "unsuitable", "untidy", "unused", "unusual", "unwieldy", "unwritten", "upbeat", "uppity", "upset", "uptight", "used", "useful", "useless", "utopian", "utter", "uttermost", "vacuous", "vagabond", "vague", "valuable", "various", "vast", "vengeful", "venomous", "verdant", "versed", "victorious", "vigorous", "violent", "violet", "vivacious", "voiceless", "volatile", "voracious", "vulgar", "wacky", "waggish", "waiting", "wakeful", "wandering", "wanting", "warlike", "warm", "wary", "wasteful", "watery", "weak", "wealthy", "weary", "wellgroomed", "wellmade", "welloff", "welltodo", "wet", "whimsical", "whispering", "white", "whole", "wholesale", "wicked", "wide", "wideeyed", "wiggly", "wild", "willing", "windy", "wiry", "wise", "wistful", "witty", "woebegone", "womanly", "wonderful", "wooden", "woozy", "workable", "worried", "worthless", "wrathful", "wretched", "wrong", "wry", "xenophobic", "yellow", "yielding", "young", "youthful", "yummy", "zany", "zealous", "zesty", "zippy", "zonked" };
            if (_mainForm.RandomAlias)
            {
                if (_mainForm.Neatusername)
                    _alias = new CultureInfo("en-US").TextInfo.ToTitleCase(adj[GetRandomNumber(0, adj.Length - 1)]) + new CultureInfo("en-US").TextInfo.ToTitleCase(adj[GetRandomNumber(0, adj.Length - 1)]) + new CultureInfo("en-US").TextInfo.ToTitleCase(adj[GetRandomNumber(0, adj.Length - 1)]) + animals[GetRandomNumber(0, animals.Length - 1)];
                else
                    _alias = GetRandomString(12);
            }
            else
                _alias = _enteredAlias + _index;

            if (_mainForm.RandomPass)
            {
                if (_mainForm.NeatPassword)
                {
                    _pass = GetRandomString(24) + GetRandomNumber(100, 1000);

                    try
                    {
                        var _client21 = new RestSharp.RestClient("https://makemeapassword.ligos.net");
                        var request21 = new RestSharp.RestRequest("api/v1/passphrase/plain?pc=1&wc=3&sp=n&maxCh=30", RestSharp.Method.GET);
                        var queryResult1 = _client21.Execute(request21);
                        _pass = queryResult1.Content + GetRandomString(2) + GetRandomNumber(100, 1000);
                    }
                    catch (Exception)
                    {
                        _pass = new CultureInfo("en-US").TextInfo.ToTitleCase(adj[GetRandomNumber(0, adj.Length - 1)]) + new CultureInfo("en-US").TextInfo.ToTitleCase(adj[GetRandomNumber(0, adj.Length - 1)]) + new CultureInfo("en-US").TextInfo.ToTitleCase(animals[GetRandomNumber(0, animals.Length - 1)]) + GetRandomString(2) + GetRandomNumber(100, 1000);
                    }
                }
                else
                    _pass = GetRandomString(24) + GetRandomNumber(100, 1000);
            }
            if (_mainForm.RandomMail)
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                var _client21 = new RestSharp.RestClient("https://newdedsecmail.now.sh?alias=" + _alias);
                var request21 = new RestSharp.RestRequest("", RestSharp.Method.GET);
                var queryResult1 = _client21.Execute(request21);

                if (queryResult1.Content == "dead")
                {
                    MessageBox.Show("Email is dead.. Steam blocked the domain.. wait for a new one");
                }
                string Provider = queryResult1.Content; //provs[GetRandomNumber(0, provs.Length - 1)];
                _mail = (_alias + Provider).ToLower();
            }

            _mainForm.AddToTable(_mail, _alias, _pass, _steamId);
            if (_auto)
            {
                _status = " Solving Captcha...";
                UpdateStatus();
            }
            else
            {
                _status = "Creating Account..";
                UpdateStatus();
            }

            StartCreation();

            bool verified;
            int tries = 5;
            do
            {
                VerifyMail();
                verified = CheckIfMailIsVerified();
                UpdateStatus();
                tries--;
                await Task.Delay(2000).ConfigureAwait(false);
            } while (!verified && tries > 0);
            if (!verified)
            {
                _status = "No Email Received.. Try again!";
                UpdateStatus();
            }
            else
            {
                FinishCreation();
                _status = "Finished";
                UpdateStatus();
                WriteAccountIntoFile();

                _status = "Finished";

                UpdateStatus();
            }
        }
        public static char cipher(char ch, int key)
        {
            if (!char.IsLetter(ch))
            {

                return ch;
            }

            char d = char.IsUpper(ch) ? 'A' : 'a';
            return (char)((((ch + key) - d) % 26) + d);
        }
        public static string Encipher(string input, int key)
        {
            string output = string.Empty;

            foreach (char ch in input)
                output += cipher(ch, key);

            return output;
        }
        public static string Reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }
        private string GetRandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var stringChars = new char[length];

            for (var i = 0; i < length; i++)
            {
                stringChars[i] = chars[Random.Next(chars.Length)];
            }
            return new string(stringChars);
        }

        private void StartCreation()
        {
            bool success;

            do
            {
                if (_auto)
                {
                    //Ask for captcha
                    _status = "Recognizing Captcha...";
                    UpdateStatus();
                    _captcha = ShowCaptchaDialog(_httpHandler, ref _status, true, _mainForm.Use2Cap);
                    if (_captcha[0] == "")
                    {
                        _status = "Error on Captcha Service";
                        UpdateStatus();
                        success = false;
                        return;
                    }
                }
                else
                {
                    //Ask for captcha
                    _status = "Creating Account...";
                    UpdateStatus();
                    _captcha = ShowCaptchaDialog(_httpHandler, ref _status, false, false);
                }
                _status = "Creating Account...";
                UpdateStatus();
                success = _httpHandler.CreateAccount(_mail, _captcha, ref _status, 0);
                UpdateStatus();

                if (_status == Error.EMAIL_ERROR)
                {
                    return;
                }
                if (_status == Error.UNKNOWN)
                {
                    return;
                }
            } while (!success);
        }

        private void VerifyMail()
        {
            if (_mainForm.AutoMailVerify)
            {
                _mailHandler.ConfirmMail(_mail);
            }
            else
            {
                //Clipboard.SetText(_mail);
            }
        }

        private bool CheckIfMailIsVerified()
        {
            return _httpHandler.CheckEmailVerified(ref _status);
        }

        private void FinishCreation()
        {
            while (!_httpHandler.CompleteSignup(_alias, _pass, ref _status, ref _steamId, _mainForm.UseCsgo))
            {
                UpdateStatus();
                switch (_status)
                {
                    case Error.PASSWORD_UNSAFE:
                        _pass = ShowUpdateInfoBox(_status);
                        break;
                    case Error.ALIAS_UNAVAILABLE:
                        _alias = ShowUpdateInfoBox(_status);
                        break;
                    default:
                        return;
                }
            }
        }

        private void WriteAccountIntoFile()
        {
            if (_mainForm.WriteIntoFile)
            {
                _fileManager.WriteIntoFile(_mail, _mainForm.istrue, _alias, _pass, _steamId, _mainForm.Path, _mainForm.original);
            }
        }

        public void UpdateStatus()
        {
            _mainForm.UpdateStatus(_index, _status, _steamId);
        }

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

        private string[] ShowCaptchaDialog(HttpHandler httpHandler, ref string _status, bool _auto, bool usetwocap = false)
        {
            if (_auto)
            {
                var captchaDialog1 = new CaptchaDialog(httpHandler, ref _status, true, usetwocap);
                string[] captcha = captchaDialog1.ans;

                Console.Write(captcha);
                captchaDialog1.Dispose();
                return captcha;
            }
            else
            {
                var captchaDialog = new CaptchaDialog(httpHandler, ref _status);
                string[] captcha = { "" };

                if (captchaDialog.ShowDialog() == DialogResult.OK)
                {
                    captcha[0] = captchaDialog.txtCaptcha.Text;
                }
                captchaDialog.Dispose();
                return captcha;
            }
        }
    }
}
