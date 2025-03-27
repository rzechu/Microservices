# Microservices

Api Gateway -> Services <-> Message broker

Services (with MongoDB databases)
- Catalog - list of items available for purchase
- Inventory - keeps track of quantity of items that a player owns
- Identity - manages a list of players (+ identity provider)
- Trading - owns the purchase process that can't grant inventory items for currency

Additional infrastructure components:
- Logging
- Distributed tracing
- Monitoring

Communication with REST + RabbitMQ + MassTransit
+ Docker containers

