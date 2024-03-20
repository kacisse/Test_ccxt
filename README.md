This project is an introduction to CCXT wrapper. The idea is to create a "template" that could help unexperimented developers (like me) to create automated trading strategies on the fly.
The main goal is to abstract all the API and websockets part by just subscribing to events/Actions:
For ex: strategy.OnNewTickAsync would subscribe in "background" to the CCXT WatchTicker websocket. This project will also include a simple Finite State Machine which is a best practice in terms of automated strategy.
