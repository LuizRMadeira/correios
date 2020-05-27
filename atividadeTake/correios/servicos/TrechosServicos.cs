namespace correios.servicos
{
    public class TrechosServicos
    {
        public virtual string[,] consultarTrechos() {
            return new string[,] { { "LS", "SF", "1" },
                                    { "SF", "LS", "2" },
                                    { "LS", "LV", "1" },
                                    { "LV", "LS", "1" },
                                    { "SF", "LV", "2" },
                                    { "LV", "SF", "2" },
                                    { "LS", "RC", "1" },
                                    { "RC", "LS", "2" },
                                    { "SF", "WS", "1" },
                                    { "WS", "SF", "2" },
                                    { "LV", "BC", "1" },
                                    { "BC", "LV", "1" }};

        }

    } 
}