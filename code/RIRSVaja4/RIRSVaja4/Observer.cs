using System;

namespace RIRSVaja4
{
    public abstract class Observer
    {
        protected Parser parser;
        public abstract void Update();
    }

    public class VrstaZavezancaObserver : Observer
    {
        public VrstaZavezancaObserver(Parser parser)
        {
            this.parser = parser;
            this.parser.Attach(this);
        }

        public override void Update()
        {
            if (!string.IsNullOrWhiteSpace(parser.GetState().VrstaZavezanca))
            {
                Console.Write(parser.GetState().VrstaZavezanca + "; ");
            }
        }
    }

    public class ZavezanostZaDDVObserver : Observer
    {
        public ZavezanostZaDDVObserver(Parser parser)
        {
            this.parser = parser;
            this.parser.Attach(this);
        }

        public override void Update()
        {
            if (!string.IsNullOrWhiteSpace(parser.GetState().ZavezanostZaDDV))
            {
                Console.Write(parser.GetState().ZavezanostZaDDV + "; ");
            }
        }
    }

    public class DavcnaStevilkaObserver : Observer
    {
        public DavcnaStevilkaObserver(Parser parser)
        {
            this.parser = parser;
            this.parser.Attach(this);
        }

        public override void Update()
        {
            if (!string.IsNullOrWhiteSpace(parser.GetState().DavcnaStevilka))
            {
                Console.Write(parser.GetState().DavcnaStevilka + "; ");
            }
        }
    }

    public class MaticnaStevilkaObserver : Observer
    {
        public MaticnaStevilkaObserver(Parser parser)
        {
            this.parser = parser;
            this.parser.Attach(this);
        }

        public override void Update()
        {
            if (!string.IsNullOrWhiteSpace(parser.GetState().MaticnaStevilka))
            {
                Console.Write(parser.GetState().MaticnaStevilka + "; ");
            }
        }
    }

    public class RacunalniskaDejavnostObserver : Observer
    {
        // Dejavnost SKD: J62.010 Računalniško programiranje
        private string racunalniskaDejavnost = "62.010";

        public RacunalniskaDejavnostObserver(Parser parser)
        {
            this.parser = parser;
            this.parser.Attach(this);
        }

        public override void Update()
        {
            if (parser.GetState().SifraDejavnosti == racunalniskaDejavnost)
            {
                Console.Write(parser.GetState().SifraDejavnosti + "; ");
            }
        }
    }

    public class MariborskoPodjetjeObserver : Observer
    {
        private string kraj = "Maribor";

        public MariborskoPodjetjeObserver(Parser parser)
        {
            this.parser = parser;
            this.parser.Attach(this);
        }

        public override void Update()
        {
            if (parser.GetState().NaslovZavezanca.ToUpper().Contains(kraj.ToUpper()))
            {
                Console.Write(parser.GetState().NaslovZavezanca + "; ");
            }
        }
    }
}