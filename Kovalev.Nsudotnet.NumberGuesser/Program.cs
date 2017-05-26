using System;
using System.Text;

namespace NumberGuesser
{
    class Program
    {
        static void Main(string[] args)
        {
            NumberGuesser game = new NumberGuesser();
            int result = game.GetResults(game.Play());
        }
    }

    class NumberGuesser
    {
        private String _name { get; set; }
        private int _wrongAnswerCount = 4;
        private int _answer;
        private DateTime _gameStartTime;
        private StringBuilder _stringBuilder = new StringBuilder();
        private String _quitString = "q";
        private int[] _history;
        private String[] _answers =
        {
            "You're wrong, kiddo.", "Here should be picture with 2 guys.", "You so low!",
            "Oh, my grandma was better than you."
        };

        private String TopPicture()
        {
            _stringBuilder.Append(
                "&A&&&&G&GGGGGGGGGhGGGGGGGGGGhGhhGGGhhGGGGGG&GG&GGhGGGGGGGhGhGGGhhGhGGGGGh&GGGhGhGGGGGGGGGGG&&&&&&&&&&&&&&&&&&&\n");
            _stringBuilder.Append(
                "A&&G&GGGGGGG&G&GGGGGhhGGGGGhGGGGGGGhGhGhGG&GGGhGGhGGGhGGGhGhGhGGGhhhGGGhGGGGhGGhGGhGGGGGGGG&&&&&&&&&&&&&&&&&A&\n");
            _stringBuilder.Append(
                "AAGGhGGG&G&GGGGGGGGGGGhGGhGGGGGGGGGhhGhhGGGGGGGGGGGGGGGhGGhhhhhhGhGhhhhGhGhGGGGGhhGGGGGGGGGGGG&&&&&&&&&&&&&&&&\n");
            _stringBuilder.Append(
                "A&GG&G&GGGGGGhGGhGGGGGGGGGGGhGGGGhGGGhGhhhGGhGGGGGGGGhGhhhhhh9hhhhhhhhhhhhhhGhhGGGGhGGGGGhGGGG&&&&&&&&&&&&&&&G\n");
            _stringBuilder.Append(
                "&&GGG&GGGGGGGhGGGhGhhhhhhhGGGhGhhhGhhhGhhGGGhGGhGGGhhhhhhhhhh9hhh99hh9hhhhhhhhhGhGhGhGGGGGGGGGGG&&&&&&&&&&&&&&\n");
            _stringBuilder.Append(
                "&&GGGGGGGGhhhGhhGGGGGhGGGhhhhGGhhhGhGGGGhGGGGGGGhGhhhhh932:.,,:;;rrr;;;rssssiiS3hGGhGGhGhGGhGG&&&&&&&&&&&&G&&&\n");
            _stringBuilder.Append(
                "GGGGGGGGGGGGGhGGGGGGhGGhGhhhhGhhGhhhGhhGhGGGGGGGhhhhXr;r;:,.,:;rrsSsSi522XSissrsiS5hGGhGhGhGGGGGGGGGGGGGGG&&&G\n");
            _stringBuilder.Append(
                "GGGGGGGGGh&GGG&GhhhGGhhhhGhhhhhhGGGhhhhGhGGGhhhGG9555SSSis:..:;r;si. :5iiss;::;rsiS553hhhhhGGhhGGGGGGGGGGG&&&&\n");
            _stringBuilder.Append(
                "GGGGGGGGGGhGGhhGGGhGhhGhhhhGhhhhhhhGhGhGhhhGGhh5irsSX2i:iSr,:;rr:;;srsr,;r;:;;rssiSSS53ss9hhGGGGhGGhGGGGGG&GGG\n");
            _stringBuilder.Append(
                "GGGGGGhhGhhGGGGGGhGGhhGhhhhhhGGGhhGhhh9hhhhGhh922X:S22s iis;:;rsrr:;::,,:,:::;;rssiSi55S;:is9Gh&hhhGGGGGGGGGGG\n");
            _stringBuilder.Append(
                "GGGGGGGGhhGGGGhGhGhhhGhGhGhhhhhhhhGGh9hG9hhhhh95X5ssrr;;s5s;:;rrr:,::,,:::,,,::;ssSSSSS5SrrisSGhGGGGG&GGG&GGGG\n");
            _stringBuilder.Append(
                "GGGGGhGhhh993999i92S2239hhhhhhhhhhhhh9hhhhhGhh9SSSisrr;;s5sr;;rr;::,.,,,,,..,,::;siSiiS5issrsXGGhhhhhh9hhhhGh\n");
            _stringBuilder.Append(
                "GGhGGGXSsssiirsisirsisssr;:;s539hhhhhh9hh99hhhhSisssr;;ri5s;:;rrr:...........,,:;ssSiiS5:;rs5hhGGGGGGG&GGG&GG\n");
            _stringBuilder.Append(
                "hGhX22Sisrr; rrr;;;rsr:;r:,,;ssss;23hhhhhhhhhhhG5isrrr:;:r5s;:;;sss:,,.. . ...,,;;rsssiiS5S59hGGGhGGGGGGGGGG&\n");
            _stringBuilder.Append(
                "hs; S22Sisr;;;;;::,:::;sr:.;ri;;;;s25:Xhhh9hhhhG5isrr;;:::Sr::::;sss;.,.......,;;rsrrssSi253GGGGGGGG&GGGGGGGG\n");
            _stringBuilder.Append(
                "hS5522Sisr;::,::,.,:rssr:,:;S:,,r;:;si559hhhhhhGSsr;;;,,sSr:,:rsissr..,,....,:;;rrrrssii25XhGGGGGGGGGGGGGGGG&\n");
            _stringBuilder.Append(
                "G &Gi55Sir;::,:,,,.:;rrr;::;rSr,,::;;rrssShhhhhh&hSsrr:,,;irSssr,:::,,..,,,,,,:;rr;;rssiSS22XhGGGGGGGGGGGGGGGG\n");
            _stringBuilder.Append(
                "&& G22Sisr;;:,:,,,.;iissr;;riis:,:;:;;rsiSXhhhhGGG9ir;;::i;rir::,:;::::,,,:,,::rr;;r;rssii2529GhhGGGGGGhhh&GGG\n");
            _stringBuilder.Append(
                "G &GX5Siss;;,:,,,,rSiisrrrrrsS;,,,:::;;rs5s9hhhG&GG2is;;;rris;;ssrrrrr;::,:,,:;r;;;;rssisi5S3hhGGGhGG&&&&&G&GG\n");
            _stringBuilder.Append(
                "GG &X5irir;;r;;::;rsr;ss,.:;sS;,,.,::;;si5rhhG&&&&&G5SsrriSiiisiSS225SSssr;:,:;r;;;;;rsssi5hhhhGhGGGh&GG&&&&&&\n");
            _stringBuilder.Append(
                "G &&92i;i;r;:,::;r;ri;:issiSsir:,,,,:;rsS5GGG&&G&&G&&5SrrS552255SS5SSisrr;;::;rr;;;;rsssr9hhhhhhGGGGGGG&&&&&&&\n");
            _stringBuilder.Append(
                "GGGGXi;ssr;:::rrrsrr:;;rrsiis;:;:,:;;si2hGGG&&&G&&&&G5Srri2S5SSSii:ris;;;;;:;r;;;;;rssshhhGhGGhhGGGGGGGG&&&&&\n");
            _stringBuilder.Append(
                "GGG &XSrsi;;rrrsrrrrr;r;;;;srr;;;:;::ssi5&G&&&&&&&&&&&G55rsi525SiSSis;:;;;;;;;;;r;rrsi39hhhhhGGGGGGGGGGGGGGG&&\n");
            _stringBuilder.Append(
                "hGGGG2isi;rsrsSX5SiSisiiirssrsr;::r;ir5G&&&&&&&&&&&&&&G22issrsr;;;:::::;:;;;r;;rrrsshhhhhGGhGGhGGGGGG&GGGGGGG\n");
            _stringBuilder.Append(
                "hGGGh35iir;r;riSS2;:.,,:sS5S5Si;;;rirSG&&G&&&&&&&&&&&&&GX5iiirrr;,,,.,,,::;rrrsssS39hhhhhhhhGhGGGGGGGGGG&GGG&\n");
            _stringBuilder.Append(
                "GGh9h9X5iirrr;sSiS55:;;i5555irr;:rssS9G&&&&&&&&&&&&&&&&&G95isss;:,,,,.,,,:;rrssi9hhhhGGhGGGGGGGGGh&GGGGGGGGGG\n");
            _stringBuilder.Append(
                "hGh99992Sss; rr;rsSi;rssssSSis;:;riS23hG&&&&&&&&&&&&&&&&&&&GXiirr::,;:::;:;sssi3h9hGhhhGGhhGGGhhhGGGGGGGGG&&&\n");
            _stringBuilder.Append(
                "GhGh999925sr;;;;;srssiisrrrrsr;rS55hh99&&&&&&&&G&&&&GGGG99hGh5Sr;rr;rrrsiSSS9hhhhhhhGhGGGGGGGGGGGGGGhGGGGGG&G\n");
            _stringBuilder.Append(
                "h999G99993Ss;;;:::::;;;;;;rss;sS559hhhhGG&h&GGGGGGGGGGh999h9G&G2SiiiS55553hhhGhhhGGhGGGGGGGGGGGGGGhGGGGGGG&GG\n");
            _stringBuilder.Append(
                "hh9999h99995s;:::::,,::::;;rrS25i5hh9hGh3399GGGGGGGGGh9h99hhhGGhhhhGhhGhhhGGGGGGGGGGGGGGhGGGhGGhGGGGGGGGGGGGG\n");
            _stringBuilder.Append(
                "hhhh9h9hh9993i;;;;:::::;:;ri55ss5hGhhGh999h9hhG&GGGGhh999GhGGhG&hGhGhhhGGGGGGGGGGGGGGGGGhGGGGhGGGGGGGGGGGGhGG\n");
            _stringBuilder.Append(
                "hhhhhhh999h9992isrrr;;rrrs2Sr;i9h99Ghhhh99hhhGGGGGGh9999hGhGhhGGG&Gh2GGhGGGGGGhGGGGGhGGGGGGGGGGhGGGGGGhGGhGGG\n");
            _stringBuilder.Append(
                "hhhh9hhh9hhh9h9999352553sr; S9hh9hGGGhhGhh9h93GGGGGhh9999GGhGhGGhhGGGG3GGGGhGhhGGGhGGGGGGGGhGGGGGGhGhGhGhGGGG\n");
            _stringBuilder.Append(
                "hhh9hhh9999h99h9h9h939999h99hhhhhhGGGGhhhGGGh9GGGGhh99hGGhGGG &GGGGG&GGGhGGhGGGGGGGGGGGGGGGGGGGGGGGhGhGGhGGGGG\n");
            _stringBuilder.Append(
                "hhhGhhhhhh99999h99hh9hhh99hhhhhhGhGGGhh9GGGGGhGhhGGhh99hGhGGGGGGG &GG9hhGGGGGGGGGGGGGGGGGGGGGhGhGGhGGGGGGGGhGG\n");
            _stringBuilder.Append(
                "Ghhh9hhG99h9999999h9h9h99hh9hhhh999hhhhhhGGGGGGGGGGGhh9GGhGGGhGGGGGGhhGGGGGhGGGGGGGGGGGhGh&GGhGhGGGGGGGGGGGGG\n");
            _stringBuilder.Append(
                "Ghhhh      9       99h     s9        G   GGGGGhGGG       ,    GGGGGh   GGGhG        Gh       G    h   GhGGGGh\n");
            _stringBuilder.Append(
                "hhhhh   9h9h   h9hh3h9      hhG    GhG   GGGhGGhGhGG   999    GhG&Gh   GGGGG    G   Gi   G    h   h  GGhGGhhG\n");
            _stringBuilder.Append(
                "h9hhh   9hhG      &hhi      Ghh    hhG      GGGGhhhh   h9h      2&&h   G&GhG    G   G    h    G   h  &GhGGhGG\n");
            _stringBuilder.Append(
                "9hhhh     Sh        h   G   hhh    hhG        GGhhhh   hG9        A9   GGGGG    G   G    h    G:     hGGGGGGG\n");
            _stringBuilder.Append(
                "hhhhh   9h9h   h,   9   h    9h    hhh   h:   Ghhhhh   hG9    G    h   GGGGG    G   G    h    G      hGhGGhGG\n");
            _stringBuilder.Append(
                "hhhh9   h9h9   9,   9        hh    hhh   h:   hhGhhh   h99    3    X   GGGGG    3   X,   9    h   h   GGGGGGG\n");
            _stringBuilder.Append(
                "hh99h      h        G   9h   hh    h9h        hhhGhh   h99        3h   Gh99     3   3X       3X   X   GGGGGhG\n");
            _stringBuilder.Append(
                "hhhhh      9       G    9h   9h    hhh       hhhhhhh   999       33h   3999   3X3   X33     3X    3    hGGhGh\n");
            _stringBuilder.Append(
                "h9h9hhhh9hh9h9h9hGGGh99h99h9hhGhhhhhhhhhhGhhh99hGhhhh9hGh99933339&Ghh399933333333333X39333333333393933999hGG9\n");
            _stringBuilder.Append(
                "hhhhhhhhhh9h9hh9hhGGh9h9hhhhhhhhhhhhhhhhhhhhh9hhhhhh9Ghhh93939GGGGG993933X33333333X33333333333339333339999999\n");
            _stringBuilder.Append(
                "hh9hhhhhhhhhhGh9hhhGh9h9h9hhhhhhhhhhhhhhhGhhhhhGhhh99hhh9999GGGhh3333993333333X3XX3333339X9333333933393939339\n");
            _stringBuilder.Append(
                "hhh9hhhhhhh9hhh9GGGG9h99h9hhhhhhhhhhhh99hhhh9hhhhGh9hhhh999GGGh333333333333333333333333333333X333393999h99999\n");
            _stringBuilder.Append(
                "Xhhhhhhhhhhhhhh9hGhhh999hhh9hhhhhhhhhhhhhhhhhhhhhGh9hh9G99GGhh3333X3933333X3X33333333333339933393333399999993\n");
            return _stringBuilder.ToString();
        }

        private String _numberIsHigher = "Number is higher than";
        private String _numberIsLower = "Number is lower than";

        public NumberGuesser()
        {
            _name = AskForName();
            _history = new int[1000];
        }

        private String AskForName()
        {
            Console.WriteLine("Yo, What's your name?");
            String name = Console.ReadLine();
            return name;
        }

        public int Play()
        {
            Random random = new Random();
            _gameStartTime = DateTime.Now;
            Console.WriteLine("Ok, {0}, Let's play some Number Guesser! ", _name);
            int i = 0, userAnswer = 0;
            String str;
            Console.WriteLine("Try to guess the number!");
            _answer = random.Next(0, 100);
            while (i < _wrongAnswerCount)
            {
                str = Console.ReadLine();
                if (str.CompareTo(_quitString) == 0)
                {
                    Console.WriteLine("I'm sorry :c");
                    return -1;
                }
                if (Int32.TryParse(str, out userAnswer))
                {
                    if (userAnswer == _answer)
                    {
                        Console.WriteLine("Congratulations, {0}!", _name);
                        return i;
                    }
                    else
                    {
                        int answerId = random.Next(0, 3);
                        if (userAnswer > _answer)
                        {
                            Console.WriteLine("{0} {1}", _numberIsLower, userAnswer);
                            _history[i] = userAnswer;
                        }
                        else
                        {
                            Console.WriteLine("{0} {1}", _numberIsHigher, userAnswer);
                            _history[i] = userAnswer;
                        }

                    }
                    i++;
                }
                else
                {
                    Console.WriteLine("You wrote shit.");
                }
            }
            return i;
        }

        public int GetResults(int counter)
        {
            switch (counter)
            {
                case -1:
                    Console.ReadKey();
                    return -1;
                case 4:
                    Random rand = new Random();
                    int num = rand.Next(0, 5);
                    Console.WriteLine("You lose!");
                    if (num == 4)
                    {
                        Console.WriteLine(TopPicture());
                    }
                    else
                    {
                        Console.WriteLine(_answers[num]);
                    }
                    Console.ReadKey();
                    break;
                default:
                    Console.WriteLine("Spent attempts: {0}", counter);
                    if (counter > 0)
                    {
                        Console.WriteLine("attempts history:");
                        for (int i = 0; i < counter; ++i)
                        {
                            Console.WriteLine("{0} {1} than answer", _history[i].ToString(), _answer > _history[i] ? "<" : ">");
                        }
                    }
                    String time = String.Format("{0:mm} min", DateTime.Now - _gameStartTime);
                    Console.WriteLine("Spent time: {0}", time);
                    Console.WriteLine();
                    Console.ReadKey();
                    break;
            }
            return 0;
        }

    }

}

