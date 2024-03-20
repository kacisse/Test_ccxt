using ccxt;
using ccxt.pro;
using Helpers;
using static Helpers.Models;
using static Helpers.Strategy;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading;
using Newtonsoft;
using Newtonsoft.Json;
using System.Collections;
using static Helpers.Miscellanious;


public class StrategyInstance
{

    public static async Task Main(string[] args)
    {
        string symbol1 = "SEI/USDT:USDT";
        HistoricalData history2 = new HistoricalData();

        Exchange exchange = new ccxt.pro.Woo();

        var strategyConfig = GetStrategyConfig(@"C:\Users\Kaci\Desktop\Visual Studio Projects\Config\\StrategyConfigs.csv");
        var exchangeConfig = strategyConfig.Where(c => c.Exchange.Equals(exchange.name)).FirstOrDefault();
        if (exchangeConfig != null)
        {
            exchange.apiKey = exchangeConfig.ApiKey;
            exchange.secret = exchangeConfig.Secret;
            exchange.uid = exchangeConfig.Uid;
        }
        else
        {
            Console.WriteLine("API credentials not found in config file");
        }

        exchange.newUpdates = true;

        List<string> symbol = new List<string> { symbol1 };

        //Activate the Websocket we want
        WebSocketManager ws = new WebSocketManager
        {
            Ticker = true,
            Orders = true,
            Positions = true,
            Trades = true
        };

        var strategy = await Strategy.CreateAsync(exchange, symbol, ws);

        /*exchange.verbose = true;*/

/*        var markets = await exchange.FetchMarkets();
        var symbolOptionChain = markets.Where(m => m.baseId == symbol1 && m.option == true).ToList();*/

        strategy.OnNewTickerAsync = OnNewTickerAsync;
        strategy.OnNewTradesAsync = OnNewTradesAsync;
        strategy.OnOrderUpdatedAsync = OnOrdersUpdateAsync;
        strategy.OnPositionUpdatedAsync = OnPositionUpdatedAsync;


        history2 = new HistoricalData(exchange, symbol1, "1m", 200, true);

        if(history2 != null)
            history2.NewHistoryItem += History2_NewHistoryItem;

/*        var histoicalTrades = await exchange.FetchTrades(symbol1, GetTimestampMs(DateTime.UtcNow.AddDays(-100)), parameters: new Dictionary<string, object> { { "paginate", true } });
*/

        //Bots Run until we stop ==============================================
        while (true)
        {
            await Task.Delay(1000);
        }
        //=====================================================================

        void History2_NewHistoryItem(OHLCV obj)
        {
            /*Console.WriteLine(history2.Count);*/
        }


        async Task OnNewTickerAsync(Ticker tick)
        {
            await Task.CompletedTask;
        }

        async Task OnNewTradesAsync(List<Trade> list)
        {
            /*            Console.WriteLine(list.First());*/
            await Task.CompletedTask;
        }

        async static Task OnPositionUpdatedAsync(List<Position> positions)
        {
            await Task.CompletedTask;
        }

        async static Task OnOrdersUpdateAsync(List<Order> orders)
        {
            await Task.CompletedTask;
        }

    }

   
}

