USE [PedidosPW3]
GO
SET IDENTITY_INSERT [dbo].[Usuario] ON 

GO
INSERT [dbo].[Usuario] ([IdUsuario], [EsAdmin], [Email], [Password], [Nombre], [Apellido], [FechaNacimiento], [FechaUltLogin], [FechaCreacion], [FechaModificacion], [FechaBorrado], [ModificadoPor], [CreadoPor], [BorradoPor]) VALUES (1, 1, N'pablokuko@gmail.com', N'Pass123', N'Damian', N'Perez', CAST(N'1988-01-01 00:00:00.000' AS DateTime), CAST(N'2021-04-04 00:00:00.000' AS DateTime), CAST(N'2021-04-05 15:47:21.703' AS DateTime), NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Usuario] ([IdUsuario], [EsAdmin], [Email], [Password], [Nombre], [Apellido], [FechaNacimiento], [FechaUltLogin], [FechaCreacion], [FechaModificacion], [FechaBorrado], [ModificadoPor], [CreadoPor], [BorradoPor]) VALUES (2, 0, N'pepe@test.com', N'Pass123', N'Alberto', N'Mendoza', CAST(N'1955-02-02 00:00:00.000' AS DateTime), CAST(N'2021-01-01 00:00:00.000' AS DateTime), CAST(N'2021-04-05 15:47:52.717' AS DateTime), NULL, NULL, NULL, NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[Usuario] OFF
GO
SET IDENTITY_INSERT [dbo].[Articulo] ON 

GO
INSERT [dbo].[Articulo] ([IdArticulo], [Codigo], [Descripcion], [FechaCreacion], [FechaModificacion], [FechaBorrado], [CreadoPor], [ModificadoPor], [BorradoPor]) VALUES (1, N'1000/01', N'Rosca 1/2 ''''', CAST(N'2021-04-05 15:39:26.910' AS DateTime), NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Articulo] ([IdArticulo], [Codigo], [Descripcion], [FechaCreacion], [FechaModificacion], [FechaBorrado], [CreadoPor], [ModificadoPor], [BorradoPor]) VALUES (2, N'1000/02', N'Rosca 3/4 ''''', CAST(N'2021-04-05 15:39:37.430' AS DateTime), NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Articulo] ([IdArticulo], [Codigo], [Descripcion], [FechaCreacion], [FechaModificacion], [FechaBorrado], [CreadoPor], [ModificadoPor], [BorradoPor]) VALUES (3, N'1000/03', N'Rosca 1/2 '''' Bronce', CAST(N'2021-04-05 15:39:52.010' AS DateTime), NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Articulo] ([IdArticulo], [Codigo], [Descripcion], [FechaCreacion], [FechaModificacion], [FechaBorrado], [CreadoPor], [ModificadoPor], [BorradoPor]) VALUES (4, N'1000/04', N'Rosca 1/2 '''' Plastico', CAST(N'2021-04-05 15:40:00.333' AS DateTime), NULL, NULL, NULL, NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[Articulo] OFF
GO
INSERT [dbo].[EstadoPedido] ([IdEstadoPedido], [Descripcion]) VALUES (1, N'Abierto')
GO
INSERT [dbo].[EstadoPedido] ([IdEstadoPedido], [Descripcion]) VALUES (2, N'Cerrado')
GO
INSERT [dbo].[EstadoPedido] ([IdEstadoPedido], [Descripcion]) VALUES (3, N'Entregado')
GO
SET IDENTITY_INSERT [dbo].[Cliente] ON 

GO
INSERT [dbo].[Cliente] ([IdCliente], [Numero], [Nombre], [Telefono], [Email], [Direccion], [CUIT], [FechaCreacion], [FechaModificacion], [FechaBorrado], [ModificadoPor], [CreadoPor], [BorradoPor]) VALUES (1, 1, N'Sanitarios Rodriguez', N'11-2222-3333', N'test@test.com', N'av siempreviva 123', N'30-2222-3333', CAST(N'2021-04-05 15:40:45.070' AS DateTime), NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Cliente] ([IdCliente], [Numero], [Nombre], [Telefono], [Email], [Direccion], [CUIT], [FechaCreacion], [FechaModificacion], [FechaBorrado], [ModificadoPor], [CreadoPor], [BorradoPor]) VALUES (2, 2, N'Ferretutti', N'11-1111-2222', N'test2@test.com', N'av donnadie 222', N'30-4444-2222', CAST(N'2021-04-05 15:41:25.240' AS DateTime), NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Cliente] ([IdCliente], [Numero], [Nombre], [Telefono], [Email], [Direccion], [CUIT], [FechaCreacion], [FechaModificacion], [FechaBorrado], [ModificadoPor], [CreadoPor], [BorradoPor]) VALUES (3, 3, N'Juan Lujan', N'11-5555-2334', N'test2@test2.com', N'av juancito 333', N'30-3333-5454', CAST(N'2021-04-05 15:42:04.620' AS DateTime), NULL, NULL, NULL, NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[Cliente] OFF
GO
SET IDENTITY_INSERT [dbo].[Pedido] ON 

GO
INSERT [dbo].[Pedido] ([IdPedido], [IdCliente], [IdEstado], [NroPedido], [Comentarios], [FechaCreacion], [FechaModificacion], [FechaBorrado], [CreadoPor], [ModificadoPor], [BorradoPor]) VALUES (1, 1, 3, 1, N'Entregar el Lunes', CAST(N'2021-04-05 15:48:28.383' AS DateTime), NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Pedido] ([IdPedido], [IdCliente], [IdEstado], [NroPedido], [Comentarios], [FechaCreacion], [FechaModificacion], [FechaBorrado], [CreadoPor], [ModificadoPor], [BorradoPor]) VALUES (2, 1, 2, 2, N'Entregar el Martes', CAST(N'2021-04-05 15:49:09.880' AS DateTime), NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Pedido] ([IdPedido], [IdCliente], [IdEstado], [NroPedido], [Comentarios], [FechaCreacion], [FechaModificacion], [FechaBorrado], [CreadoPor], [ModificadoPor], [BorradoPor]) VALUES (5, 1, 1, 3, N'Entregar el Miercoles', CAST(N'2021-04-05 15:49:26.200' AS DateTime), NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Pedido] ([IdPedido], [IdCliente], [IdEstado], [NroPedido], [Comentarios], [FechaCreacion], [FechaModificacion], [FechaBorrado], [CreadoPor], [ModificadoPor], [BorradoPor]) VALUES (6, 2, 2, 4, N'', CAST(N'2021-04-05 15:49:42.037' AS DateTime), NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Pedido] ([IdPedido], [IdCliente], [IdEstado], [NroPedido], [Comentarios], [FechaCreacion], [FechaModificacion], [FechaBorrado], [CreadoPor], [ModificadoPor], [BorradoPor]) VALUES (7, 2, 1, 5, NULL, CAST(N'2021-04-05 15:49:50.227' AS DateTime), NULL, NULL, NULL, NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[Pedido] OFF
GO
INSERT [dbo].[PedidoArticulo] ([IdPedido], [IdArticulo], [Cantidad]) VALUES (1, 1, 10)
GO
INSERT [dbo].[PedidoArticulo] ([IdPedido], [IdArticulo], [Cantidad]) VALUES (1, 2, 20)
GO
INSERT [dbo].[PedidoArticulo] ([IdPedido], [IdArticulo], [Cantidad]) VALUES (1, 3, 30)
GO
INSERT [dbo].[PedidoArticulo] ([IdPedido], [IdArticulo], [Cantidad]) VALUES (2, 2, 100)
GO
INSERT [dbo].[PedidoArticulo] ([IdPedido], [IdArticulo], [Cantidad]) VALUES (2, 3, 200)
GO
INSERT [dbo].[PedidoArticulo] ([IdPedido], [IdArticulo], [Cantidad]) VALUES (5, 1, 15)
GO
INSERT [dbo].[PedidoArticulo] ([IdPedido], [IdArticulo], [Cantidad]) VALUES (5, 2, 22)
GO
INSERT [dbo].[PedidoArticulo] ([IdPedido], [IdArticulo], [Cantidad]) VALUES (5, 3, 30)
GO
INSERT [dbo].[PedidoArticulo] ([IdPedido], [IdArticulo], [Cantidad]) VALUES (5, 4, 60)
GO
INSERT [dbo].[PedidoArticulo] ([IdPedido], [IdArticulo], [Cantidad]) VALUES (6, 1, 200)
GO
INSERT [dbo].[PedidoArticulo] ([IdPedido], [IdArticulo], [Cantidad]) VALUES (6, 3, 700)
GO
