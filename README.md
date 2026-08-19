# Payment Gateway Component

Sistema de pasarela de pagos que integra MercadoPago como procesador de transacciones. Permite a los usuarios autenticarse mediante un código PIN enviado por email, agregar productos a un carrito, iniciar el proceso de pago a través de MercadoPago y consultar el historial de sus compras.

## Stack tecnológico

| Capa | Tecnología |
|------|-----------|
| Frontend | React 19, Vite 8, React Router v7 |
| Backend | .NET 10, ASP.NET Core Web API |
| Base de datos | SQL Server 2022 |
| Caché | Redis (PINs de autenticación) |
| Autenticación | JWT |
| Pagos | MercadoPago SDK |
| Arquitectura | Clean Architecture (Domain → Application → Infrastructure → API) |

## Estructura del proyecto

```
Payment-Getaway-Component/
├── Backend/
│   └── PaymentGateway/
│       ├── PaymentGateway.API              # Controllers, middleware, startup
│       ├── PaymentGateway.Application       # Interfaces, DTOs, contratos
│       ├── PaymentGateway.Domain            # Entidades del dominio
│       ├── PaymentGateway.Infrastructure    # Servicios, repositorios, persistencia
│       ├── compose.yaml                     # Docker Compose (SQL Server + Redis)
│       └── PaymentGateway.sln
├── Frontend/
│   └── PaymentFront/                        # React SPA (Vite)
│       ├── src/
│       │   ├── api/                         # Cliente HTTP con JWT
│       │   ├── components/                  # Navbar, ProductCard, CartItem
│       │   ├── context/                     # AuthContext, CartContext
│       │   └── pages/                       # Products, Cart, Auth, CheckoutResult, MyPurchases
│       └── package.json
└── README.md
```

## Prerrequisitos

- [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0)
- [Node.js 18+](https://nodejs.org/)
- [Docker](https://www.docker.com/) (para SQL Server y Redis)
- [ngrok](https://ngrok.com/) (para recibir webhooks de MercadoPago en desarrollo local)

## Inicio rápido

1. **Levantar infraestructura y backend:**

   ```bash
   cd Backend/PaymentGateway
   docker compose up -d
   dotnet ef migrations add InitialCreate --project PaymentGateway.Infrastructure --startup-project PaymentGateway.API
   dotnet ef database update --project PaymentGateway.Infrastructure --startup-project PaymentGateway.API
   dotnet run --project PaymentGateway.API
   ```

   La API estará disponible en `http://localhost:5076` y Swagger en `http://localhost:5076/swagger`.

2. **Levantar el frontend:**

   ```bash
   cd Frontend/PaymentFront
   npm install
   npm run dev
   ```

   El SPA estará disponible en `http://localhost:5173`.

Para más detalles sobre la configuración de cada parte, consultar:
- [Backend README](Backend/README.md)
- [Frontend README](Frontend/README.md)

## Licencia

MIT License — ver [LICENSE](LICENSE) para más detalles.
