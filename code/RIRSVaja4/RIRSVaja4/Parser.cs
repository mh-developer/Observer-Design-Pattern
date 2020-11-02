using System;
using System.Collections.Generic;

namespace RIRSVaja4
{
    public class Parser
    {
        private List<Observer> _observers = new List<Observer>();
        private Zavezanec _state;

        public void Attach(Observer o)
        {
            _observers.Add(o);
        }

        public void Detach(Observer o)
        {
            _observers.Remove(o);
        }

        public Zavezanec GetState()
        {
            return _state;
        }

        private void Notify()
        {
            foreach (var observer in _observers)
            {
                observer.Update();
            }
        }

        public void PodatkiPrebrani(Zavezanec value)
        {
            _state = value;
            Notify();
        }

        public void NaletelNaNapako(string vrstica)
        {
            Console.WriteLine($"Podatki v vrstici št. {vrstica}, niso popolni.");
        }
    }
}