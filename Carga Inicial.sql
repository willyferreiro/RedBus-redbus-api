USE [redbusdb]
GO
SET IDENTITY_INSERT [dbo].[Usuario] ON 

GO
INSERT [dbo].[Usuario] ([idUsuario], [telefone], [nome], [senha], [tipoUsuario]) VALUES (1, CAST(111111 AS Numeric(11, 0)), N'Motorista 1', N'moto      ', N'M')
GO
INSERT [dbo].[Usuario] ([idUsuario], [telefone], [nome], [senha], [tipoUsuario]) VALUES (2, CAST(22222 AS Numeric(11, 0)), N'Responsavel 2', N'resp      ', N'R')
GO
INSERT [dbo].[Usuario] ([idUsuario], [telefone], [nome], [senha], [tipoUsuario]) VALUES (3, CAST(33333 AS Numeric(11, 0)), N'Responsavel 3', N'resp      ', N'R')
GO
SET IDENTITY_INSERT [dbo].[Usuario] OFF
GO
SET IDENTITY_INSERT [dbo].[Mensagem] ON 

GO
INSERT [dbo].[Mensagem] ([idMensagem], [idUsuarioDe], [idUsuarioPara], [dataMensagem], [mensagem], [entregue], [visualizada]) VALUES (1, 2, 1, CAST(N'2017-05-03T20:45:00.000' AS DateTime), N'teste mensagem - primeira mensagem', 0, 0)
GO
SET IDENTITY_INSERT [dbo].[Mensagem] OFF
GO
INSERT [dbo].[Responsavel] ([idUsuario]) VALUES (2)
GO
INSERT [dbo].[Responsavel] ([idUsuario]) VALUES (3)
GO
INSERT [dbo].[Motorista] ([idUsuario], [emViagem], [posicao_Latitude], [posicao_longitude], [adimplente], [foto]) VALUES (1, 0, NULL, NULL, 1, NULL)
GO
SET IDENTITY_INSERT [dbo].[Filho] ON 

GO
INSERT [dbo].[Filho] ([idFilho], [idResponsavel], [idMotorista], [nome], [emViagem], [embarcado], [posicao_latitudeCasa], [posicao_longitutdeCasa], [posicao_latitudeEscola], [posicao_longitutdeEscola], [foto], [fotoCompleta]) VALUES (1, 2, 1, N'Filho 1', 0, NULL, NULL, NULL, -23.55052, -46.633309, NULL, NULL)
GO
INSERT [dbo].[Filho] ([idFilho], [idResponsavel], [idMotorista], [nome], [emViagem], [embarcado], [posicao_latitudeCasa], [posicao_longitutdeCasa], [posicao_latitudeEscola], [posicao_longitutdeEscola], [foto], [fotoCompleta]) VALUES (2, 2, 1, N'Filho 2', 0, NULL, NULL, NULL, 19.075984, 72.877656, NULL, NULL)
GO
INSERT [dbo].[Filho] ([idFilho], [idResponsavel], [idMotorista], [nome], [emViagem], [embarcado], [posicao_latitudeCasa], [posicao_longitutdeCasa], [posicao_latitudeEscola], [posicao_longitutdeEscola], [foto], [fotoCompleta]) VALUES (3, 3, 1, N'Filho 1', NULL, NULL, NULL, NULL, 37.386052, -122.083851, NULL, NULL)
GO
INSERT [dbo].[Filho] ([idFilho], [idResponsavel], [idMotorista], [nome], [emViagem], [embarcado], [posicao_latitudeCasa], [posicao_longitutdeCasa], [posicao_latitudeEscola], [posicao_longitutdeEscola], [foto], [fotoCompleta]) VALUES (4, 3, 1, N'Filho 2', NULL, NULL, NULL, NULL, -23.55052, -46.633309, NULL, NULL)
GO
INSERT [dbo].[Filho] ([idFilho], [idResponsavel], [idMotorista], [nome], [emViagem], [embarcado], [posicao_latitudeCasa], [posicao_longitutdeCasa], [posicao_latitudeEscola], [posicao_longitutdeEscola], [foto], [fotoCompleta]) VALUES (5, 2, 1, N'Filho 1', 1, 0, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Filho] ([idFilho], [idResponsavel], [idMotorista], [nome], [emViagem], [embarcado], [posicao_latitudeCasa], [posicao_longitutdeCasa], [posicao_latitudeEscola], [posicao_longitutdeEscola], [foto], [fotoCompleta]) VALUES (6, 2, 1, N'Filho 2', 1, 0, NULL, NULL, NULL, NULL, NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[Filho] OFF
GO
SET IDENTITY_INSERT [dbo].[Viagem] ON 

GO
INSERT [dbo].[Viagem] ([idViagem], [idMotorista], [dataInicioViagem], [dataFimViagem], [posicaoInicio_latitude], [posicaoInicio_longitude], [posicaoFim_latitude], [posicaoFim_longitude], [statusViagem]) VALUES (39, 1, CAST(N'2017-05-09T00:51:23.160' AS DateTime), NULL, -23.5813472, -46.5788867, 0, 0, CAST(1 AS Numeric(1, 0)))
GO
INSERT [dbo].[Viagem] ([idViagem], [idMotorista], [dataInicioViagem], [dataFimViagem], [posicaoInicio_latitude], [posicaoInicio_longitude], [posicaoFim_latitude], [posicaoFim_longitude], [statusViagem]) VALUES (40, 1, CAST(N'2017-05-09T01:26:39.553' AS DateTime), NULL, -23.5813472, -46.5788867, 0, 0, CAST(1 AS Numeric(1, 0)))
GO
SET IDENTITY_INSERT [dbo].[Viagem] OFF
GO
INSERT [dbo].[Viagem_Filho] ([idVIagem], [idFilho], [dataEmbarque], [dataDesembarque], [posicaoEmbarque_latitude], [posicaoEmbarque_longitude], [posicaoDesembarque_latitude], [posicaoDesembarque_longitude]) VALUES (39, 5, NULL, NULL, 0, 0, 0, 0)
GO
INSERT [dbo].[Viagem_Filho] ([idVIagem], [idFilho], [dataEmbarque], [dataDesembarque], [posicaoEmbarque_latitude], [posicaoEmbarque_longitude], [posicaoDesembarque_latitude], [posicaoDesembarque_longitude]) VALUES (39, 6, NULL, NULL, 0, 0, 0, 0)
GO
INSERT [dbo].[Viagem_Filho] ([idVIagem], [idFilho], [dataEmbarque], [dataDesembarque], [posicaoEmbarque_latitude], [posicaoEmbarque_longitude], [posicaoDesembarque_latitude], [posicaoDesembarque_longitude]) VALUES (40, 1, NULL, NULL, 0, 0, 0, 0)
GO
INSERT [dbo].[Viagem_Filho] ([idVIagem], [idFilho], [dataEmbarque], [dataDesembarque], [posicaoEmbarque_latitude], [posicaoEmbarque_longitude], [posicaoDesembarque_latitude], [posicaoDesembarque_longitude]) VALUES (40, 2, NULL, NULL, 0, 0, 0, 0)
GO
