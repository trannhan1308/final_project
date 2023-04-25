USE [master]
GO
/****** Object:  Database [DbHospital]    Script Date: 11/2/2021 9:07:04 AM ******/
CREATE DATABASE [DbHospital]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DbHospital', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\DbHospital.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'DbHospital_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\DbHospital_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DbHospital].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DbHospital] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DbHospital] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DbHospital] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DbHospital] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DbHospital] SET ARITHABORT OFF 
GO
ALTER DATABASE [DbHospital] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [DbHospital] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DbHospital] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DbHospital] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DbHospital] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DbHospital] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DbHospital] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DbHospital] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DbHospital] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DbHospital] SET  ENABLE_BROKER 
GO
ALTER DATABASE [DbHospital] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DbHospital] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DbHospital] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DbHospital] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DbHospital] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DbHospital] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [DbHospital] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DbHospital] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [DbHospital] SET  MULTI_USER 
GO
ALTER DATABASE [DbHospital] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DbHospital] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DbHospital] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DbHospital] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [DbHospital] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [DbHospital] SET QUERY_STORE = OFF
GO
USE [DbHospital]
GO
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 11/2/2021 9:07:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__MigrationHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ContextKey] [nvarchar](300) NOT NULL,
	[Model] [varbinary](max) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC,
	[ContextKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LoaiBenh]    Script Date: 11/2/2021 9:07:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoaiBenh](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [nvarchar](150) NOT NULL,
	[Name] [nvarchar](500) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[CreatedAt] [datetime] NOT NULL,
	[UpdatedAt] [datetime] NOT NULL,
	[CreatedBy] [nvarchar](max) NULL,
	[UpdatedBy] [nvarchar](max) NULL,
	[IsActive] [bit] NOT NULL,
	[IsDelete] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.LoaiBenh] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Medicines]    Script Date: 11/2/2021 9:07:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Medicines](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [nvarchar](150) NOT NULL,
	[Name] [nvarchar](250) NOT NULL,
	[NgayNhap] [datetime] NOT NULL,
	[Quantity] [int] NOT NULL,
	[GiaBan] [decimal](18, 2) NOT NULL,
	[GiaNhap] [decimal](18, 2) NOT NULL,
	[CreatedAt] [datetime] NOT NULL,
	[UpdatedAt] [datetime] NOT NULL,
	[CreatedBy] [nvarchar](max) NULL,
	[UpdatedBy] [nvarchar](max) NULL,
	[IsActive] [bit] NOT NULL,
	[IsDelete] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.Medicines] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Patients]    Script Date: 11/2/2021 9:07:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Patients](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [nvarchar](150) NOT NULL,
	[Name] [nvarchar](250) NOT NULL,
	[Address] [nvarchar](max) NULL,
	[DateOfBirth] [nvarchar](max) NULL,
	[Gender] [int] NOT NULL,
	[Room] [nvarchar](150) NOT NULL,
	[CreatedAt] [datetime] NOT NULL,
	[UpdatedAt] [datetime] NOT NULL,
	[CreatedBy] [nvarchar](max) NULL,
	[UpdatedBy] [nvarchar](max) NULL,
	[IsActive] [bit] NOT NULL,
	[IsDelete] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.Patients] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PhieuKham]    Script Date: 11/2/2021 9:07:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhieuKham](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [nvarchar](150) NOT NULL,
	[PatientId] [int] NOT NULL,
	[DoctorId] [int] NOT NULL,
	[TrieuChung] [nvarchar](max) NOT NULL,
	[Price] [decimal](18, 2) NOT NULL,
	[NgayTaiKham] [datetime] NULL,
	[CreatedAt] [datetime] NOT NULL,
	[UpdatedAt] [datetime] NOT NULL,
	[CreatedBy] [nvarchar](max) NULL,
	[UpdatedBy] [nvarchar](max) NULL,
	[IsActive] [bit] NOT NULL,
	[IsDelete] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.PhieuKham] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Recipience]    Script Date: 11/2/2021 9:07:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Recipience](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
	[PatientId] [int] NOT NULL,
	[CreatedAt] [datetime] NOT NULL,
	[UpdatedAt] [datetime] NOT NULL,
	[CreatedBy] [nvarchar](max) NULL,
	[UpdatedBy] [nvarchar](max) NULL,
	[IsActive] [bit] NOT NULL,
	[IsDelete] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.Recipience] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RecipienceDetail]    Script Date: 11/2/2021 9:07:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RecipienceDetail](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RecipienceId] [int] NOT NULL,
	[MedicineId] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
	[Price] [decimal](18, 2) NOT NULL,
	[CreatedAt] [datetime] NOT NULL,
	[UpdatedAt] [datetime] NOT NULL,
	[CreatedBy] [nvarchar](max) NULL,
	[UpdatedBy] [nvarchar](max) NULL,
	[IsActive] [bit] NOT NULL,
	[IsDelete] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.RecipienceDetail] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 11/2/2021 9:07:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [nvarchar](150) NOT NULL,
	[Name] [nvarchar](250) NOT NULL,
	[Address] [nvarchar](max) NULL,
	[Gender] [int] NOT NULL,
	[Phone] [nvarchar](max) NULL,
	[Position] [int] NOT NULL,
	[DateOfBirth] [nvarchar](max) NULL,
	[Email] [nvarchar](250) NOT NULL,
	[Password] [nvarchar](250) NOT NULL,
	[CreatedAt] [datetime] NOT NULL,
	[UpdatedAt] [datetime] NOT NULL,
	[CreatedBy] [nvarchar](max) NULL,
	[UpdatedBy] [nvarchar](max) NULL,
	[IsActive] [bit] NOT NULL,
	[IsDelete] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__MigrationHistory] ([MigrationId], [ContextKey], [Model], [ProductVersion]) VALUES (N'202110290315015_Initial', N'OA.Entities.Migrations.Configuration', 0x1F8B0800000000000400ED5D5B6FE3B8157E2FD0FF20F8A92DB27692C102DBC0D945624F16C14E2E8D338BBE0D1889B689EAE24A543646D15FD687FEA4FD0B4BDD295E2452926DC5110618C414F9F1A2C3EF9CC3CBD1EFFFFBFFF4A737C7365EA11F20CFBD1C9D8D4F4706744DCF42EEEA7214E2E5773F8C7EFAF1CF7F9A7EB69C37E3D72CDFA7281F29E90697A335C69B8BC92430D7D001C1D841A6EF05DE128F4DCF9900CB9B9C9F9EFE7D72763681046244B00C63FA14BA183930FE417ECE3CD7841B1C02FBCEB3A01DA4E9E4C9224635EE8103830D30E1E5E8E16AFC9914C6080623E3CA4680346101EDE5C800AEEB618049032FBE0670817DCF5D2D362401D8CFDB0D24F996C00E60DAF08B22BB6A1F4ECFA33E4C8A8219941906D8733401CF3EA58332618B371ADA513E6864D8E211DA46BD8E87EE72F4C503E81ABAEB62E8D84A2F66B61F15288DF0382B3766014E0C2ADB492E194480A27F27C62CB471E8C34B1786D807F689F118BED8C8FC056E9FBD7F41F7D20D6D9B6E32693479564A20498FBEB7813EDE3EC165DA915B6B644CCAE5266CC1BC185526E9DAAD8B3F9D8F8C7B523978B1612E11D4302CB0E7C39FA10B7D80A1F5083086BE1B61C0784CB9DA99BA664480B3DA880892693432EEC0DB17E8AEF09A4CB0EFC9C4B9416FD0CA52D2167C75119975A410F64328686175ADD1FF15B57E7FBA935AE730307DB44944565A39F953A9F29A71F561F43EAE7056D39CFC7C468E7EABBF6EAC8E90D2365D6F77DEFBB4CD7BA8E936B832317ACDA5E9DAF36C085CEDB1B90DE6D0865813673A2998AB92CFEEA0854CE4425D3ECBCA8D598081CFDE119F9DEFA8D615D8DEAFC1A63531FC2304E9E056BFA66A949F11B80639B3CEA1891C608F8C479FFC959A6B3F8C8C850922C446F0A5CE768D3F30F647606C82730F5ED12A261B06F18908D206117702CE210688C8D613B4E38CC11A6D12B37DCC66CA38F85BC6D064887CCF79F26C012297F9DB33F0573012144FB5C4C20B7DB3A91E92C1ABEA23B6BC743806FD24AEAB18AFFA5AAB913281688BD30DF93FFAC88403370FDCBC236E2ED875F79C9C31AC3A27672CAEAF69F4FA439753E851F140BD4F541951AF1A689AE63A66CC830C7A455C578D07D20D3DCCC1F66179E385AED59A3DF7B916430693C8106EAB280725F4D195502A48359C9D53699E5D44D56CAE0A86E6B23657374D1C9BE64A47D9B91128AA464A271D205D8D93161B33C5075D23219D0FB4C67665593E0C823DA8560C1F96D7C8C7EB9DD745DEBC05FD76CAF0C9F39CFDCBC0A0823FBC0A5E2318FEB2064E205462F9E32A252CCDC4292C794E919A5253C1E286B7361FE4BA56A9EDEA2A961D1265259B15E45FD2A06825D4721045DB91BB34F74CD2FBB628CF3E9195D93A8CBADE9AF47AB5A619EDDE3D0314CD035E070D6AB0B6CD1F5A0D26934B51056699AB346092877342A519755DD02AD7B9A5D2AE6F7395DFACACF8BE06442DE92ABDB8D0B854745076120219BCCA5E7A7A8F6BCFDDFDD2F2A317207A31B8A1CDB1472FFAB313AFA4ED5B741E4110FCE6F9D6FE6B1EAC8E8F6E75683BDF1A9647BDEBCD98282A4AFC2A083C13C5EDAC3900536C1597C7E2B36B19DAFBC6897C542DAA13B1216A1E6D886227CDBE1CFD8D7B093A15E7635754CC1F382D577836622D86073711172392BEC8BB9981C004162F1E64ACAD720A3132A01F697960CF884410B305B998B748904B3A026CDD6E31408AC64DD4D0BC4AF6C91C6E22CDE862DD77ABD216FA600EDFA6BC6A6650EBC6703AA184B95AC6A5F3502661F5EE40215882F51F7551AE9FFD45458CBDDD37F1ADEBCA1EA4B6EEB5A934A158A5E989A866AE9FBA08717EE0CE84955B6BA56A62771EFB2FAF4C6F0E22B0CCBB536903B53C791091AD58A9AFD7E02A422B3A39D5C45A380AB1ADEFCE5ECD83E3105CF9010F6D1B5474C4704FE6AFE8A089CE2CEA9370D776ED904630FF8E555A533EE9BE07894F5C40528634DE857EBEACE8C3280DBE61C1A22D3132D375DB2075CE59318C301710A768D9B562224C85C7994A1C7F679993E93258E62888C078FFAD068C7D7B2250F9745406AF8655064CB95084C6A9A43A286A518207E30DC01AB8D8ED102031EE08834289A4FC95F06B0D06554EF92C3B3B939A2C51E4BD160A0E37599B2C4650555082CE126979E0140655BEC8C48FA59A23ACE70A53DDA225AF62C86A9D5E0A3295BE1D8C52BEA5A6324C428356D30DEB62A058CB95C6CC19A4F560559DBDA99AA01AC3A5E00108A7A4EA643CD888559C15D6E0369905DAD806ED9EDF04D6A6DA1BAB18DE6CD93AB759F267D3491249264D984E242167A67760B341EE8A0A4193A6188B24FECCECBB857E7C1627C1989881204C4BDEDABC264266600599A7C98EEE0DF2033C0718BC8068A7616639826C858526D1CD594DAC11C6BFC74C6B6725A2BF9352A23031B93EE70DDA14E086F4CC896CE478779B7AE3F51046140E08D8C0176CAACF3C3B745CB9D92E2F9D6C93D3E59314758464CB9B464852D4114A977768A0D2038D3E153B8BA58E15C9EA58D4DE228D45256BB72BDAF313B4EB9A3BD2A0D02E168B4A56C72A76084B7294A7EA20657B8465A42C95479A4E9899C13976DC24E47CE7F2AC569AF38509D974CE731E95FE9CAF8738DE395F041B29A1E4A9EA48C585731AA9485547CA228ED038599A160ADFB13C7160B181C53A6331DE166DCA66D2A51C7D565387DA0DBB95170A699CEA25443922BD034FE355EDCCCBD1BAE3ABF440390D93260D2C33B0CC0E58A60B7EE98459F6CD291DF83854AC83928B43A51FCE63A2F6124B6C22DF6294630D8C32304AF658C228F9D261533A613775F4B9A416E1785DAFFCB6000D9227EA501A753ABECC69D4030DC729BD5D50F29BD2340DF32FBE495E32FBE29481C00602EB8EC08A1DA8C614C66D253720B17A8CBED25897164771E8B4C442D2A3A87224FA7A308D45A7EFD73F2B5DEB6597CAF20703B90DE4D619B92587069AF25AF9608B3EA7D594EF2B9FF5C72CEBC68C4AAF6996B82B49D2C0C82F619660F2D4C3999AE9654B1A294DD2D160D9CDC9B202CB52074E1E38599393B9031C6C96BCF63425FF9D1FE0480F4FD47F48883B4D916489029278AFC88A4E522CB60186CE38CA305EFCDB9ED9C919A62CC31D70D11206388923303A3F3D3B673E49D49FCF034D82C0B205874FA8800CD52730F611140145A35B1BF640F74A331507C17D05BEB9063E1F09A14598032168FCC99DF6315C33ECBF38E0EDAF3460A36FE64454833BB960DE1889BB60DEAA87DC25F25668EC45F117845B5F12AFC768FECD9B617E369F9FE74D4099EFC3349E04EC2702E2716DF575186BC75F87E91C7FE0A6A3E226B5330FEF96A3445F19892BE22E40DD123FF3ED72F49FB8E08571FBCF6F74D913E3C12786E385716AFCB7830F94A836A128D9AA015DD0562906E0C02A03ABA8B1CA91F189C83C69F402F92F483496D3AEBD0F2EECA92A5BE5055B91D5400547450595C715DE2D0FBC1FDF8789B0D892B4B8A882ADF0CA51199B582574F4FDCEDEC3C040C7C540D5670D060EEA91F26763A5ABD69E956B55391F625D3A2D7AE03209C2A68BD865586FFE70845771106120BB776570B537904A41ABDBB9854C60EA26ADE9DA802C859EEEEC0DB291A53B031E78F63DF36C973194F9A8569521AF7618AFAD3EE2474781EC1A058653B8ABAEA2BE8C2EC2BF1D69CC63269E973CD2D75E845010A7AC3A8AD94EC4AEEE2868E732A772A69EAFF4FDC52C6643DAD1EF768F1158FB266FF5B7C27A2271FD09DDFA8E654E142652A8628F4FEA946E53F759ECDA440C6EF8B63F90B9D7503C0E69F0F526BA2F1B628E7DEF5818BFB778A185D3230DE39B1CB426CEE68B47A42471A0B25C9C00B035F25E0D57239F4554A33C882A5BA55C7AB9AAE559454DE0BF23AFDC12A536A8D65E5B2FA7E0B84AB91CA21AA51133B9FA788389AF91CF23AC33CB565B29E3A7701532CF459589C3CDF62398B16CE28823B1F114A442F914A2726CECDE852C16CA81E06A5ED510490558726D791783D27584623107088349F46B68F6108FB8ABC19113BC2C005097C37390E0C30D3B7A1046D20830CCDF4323C65AE8468BEBC9AF390CD0AA8098124C179A25332DCF73EB2EBDCC66645A9465E10E0B6360111BEECAC768094C4C1E9B3008E22F2CFE0AEC30DEF57881D6ADFB10E24D884997A1F36297AE2146566755FD7114E5729BA70FF101C2A08B2E9066A2681BE0C1BD0E916DE5EDBE11ACB54B20227336DD3D8CDE258E761157DB1CE99EBBCF2B034A872FB7C29FA1B3B10958F0E02E40B4B3A0DF36A24CBEC01530B7D975423948FD8B280FFB748EC0CA074E906214E5C94F22C396F3F6E31FE16901ABFDA10000, N'6.1.0-30225')
INSERT [dbo].[__MigrationHistory] ([MigrationId], [ContextKey], [Model], [ProductVersion]) VALUES (N'202110290758146_UpdateTbaleRecipience', N'OA.Entities.Migrations.Configuration', 0x1F8B0800000000000400ED5D5B6FE336167E5FA0FF41D0D3EE22B5930C0AB481D322B1678AA0934BE34CB16F0346626CA2BA78252A8DB1D85FB60FFB93FA174ADD295E2452921DC5110618C414F91D923AFCCEE1EDE8CFFFFD7FF6D38BEB18CF300891EF9D9B279363D3809EE5DBC85B9D9B117EFAF67BF3A71FBFF9DBECA3EDBE18BFE5F93EC4F948492F3C37D7186FCEA6D3D05A431784131759811FFA4F7862F9EE14D8FEF4F4F8F887E9C9C9141208936019C6EC3EF2307261F283FC9CFB9E05373802CEB56F4327CCD2C99365826ADC0017861B60C173F3F662F29114C60886A671E12040AAB084CE936900CFF331C0A482675F42B8C481EFAD961B92009C87ED06927C4FC0096156F1B332BB6A1B8E4FE3364CCB8239941585D87735014F3E649D32658BB7EA5AB3E834D26D490F6DE356275D776E7EF601BA84DEBAEC3A56E8D9DC09E202951E9EE4E5262CC09141653B2A34832850FCEFC898470E8E0278EEC10807C03932EEA2470759BFC0ED83FF3BF4CEBDC871E82A934A93679504927417F81B18E0ED3D7CCA1A72659BC6B45A6ECA162C8A5165D2A65D79F8C3A969DC10E1E0D181854650DDB0C47E007F861E0C0086F61DC018065E8C01933EE5A433B2E6448173694405C930328D6BF0F2197A2BBC2603EC3B32703EA11768E729590DBE78888C3A5208071114D4B05E6AFC7F8DD4EF8E77227501432B409B5465A5C2C99F4AC21BFA3580F1FBB8C0B9A405F9F9805CFD5A7FD9D83D216575BADCEEBCF5599DF720E92ABCB0307A2EB4E9D2F71D083CEDBEB90A17D081581367362D99AB96CFAEA18D2CE4415D3ECBCB4D588091CFDE109F9DEE48EA0A6C6FD660D399187E8D40D6B9F5AFA91EE567042E41C1AC0B68211738A6711790BF3277ED7BD3585A20466C055F696CDFF82363BF07C6263837E019AD12B26110EF89226D10994EC005C40011DDBA874E92315CA34DEAB64FD84C39077FCD199A7451E0BBF7BE2340E4327F7D00C10AC68AE2AB9658FA5160B5B5433278557BC4969776C7689FC4B2CAFE6A965A8F942B44579C7EC8FF2E40161CB979E4E61D7173C9AEBBE7E49C61D5393967717D4BA3D71EBA9C428BCA07EA6DA2CA885AD5C2D2B4B731131E64B42B62590D33907EE8619F0B28A407C88BC75DADDB6839DEBBE5C814A981680BFE2BB28BF895CD5543AB5CD6F636A2CD6CA4BDA5509E9108AC4B2B4B917590AE99C88A4D98E2A3819090CE3B5A18BBB0ED0086E1EEED217913B74F9728C0EB9DCB226FDE8641376378EFFBEEFE756034C1EFDE04AF118C7E590337141AB1E2719D119666E20C963CA7C84CA9996071C53BBB0F725BAB54777513CB7689B291CD0BF22F6934B4126A791543DBD37469E15BA4F55D511E02A22BF3751437BD33E90D6A2132DE727B00281E07BC0D1ACD60639DDFB5194C0797A209CC33D759C0340F37099566D49D82D64D9D3B1AEDE63AD7CD9B950DDF979098255DA397149A548A8EC64E4220E3AC729033BDBBB5EFED7E3DF8CE0F11BD18DCD2E7D8E32CFAA39BACA4ED5B75EE4018FEE107F6FE258F5EC77BF73AB427DF1A9E47F3D49B7151548CF84518FA164AEAD9706AA5DCDFADF6C547CF36B4377B53FDA85B54276A43CC3CDA10C34EAA7D6EFE937B093A828BBE2B05F3A744AB024F4CD663B8F552753162ED8B673773105AC0E6D583F4B55D4D214E060C622B0F9C39D108E2B6200FF31E09F2484380A3DB2C0648D1B9892B5A88649F2CE026B68C1ED67DB72A75A14FD3F0752A44339DDAD487B329A5CCF53A2E1D87320D6B9E0E948A2558FF5157E5E6D15F0A62FCEDA1A96F5353F6A0B54DAF4DA50AE52ACD4054359FFAA9AB10370FDC99B2726BAD942476E771F8FACAB4E655149679772A75A096275F45656B56EA9B2DB88AD28A8E3BB5F1160E426D9B9BB357F7E03014577EC043DB07159D0BDC93FB2B3A68A2338A86A4DC8D4D7B4D27987FC72AB5A91E4FDF83C6A75340528654DE8341B1AC18C0380DBE60C1A22D7132B375DB309B9CB36A18632E21CED0F2BBC04499CA1967A671FC45634EA7AB60F9444104C6CFDF1AC0D8B72702950F4765F07A5865C08C0B45689C496A82A216257830DE016C804BA61D0224663AC2A0502A297F25FC5A834195533E80CE8EA4364B1445AB858AC30DD6368B1194084AD15922AD769C42A7CA1799F8BE549B08EB4D85A966D19A57D3658D935E0A32D3BE1DF452B1A5A6D24D428756731AD64747B19E2B8D593048E7CEAA3B7B53374035BA4B6106201C92AA83F1D57AACE6ACB006B7C93CD0D63E68FFFC26F036D5DE584DF7E6CBD685CF523C9B4DD3F02F59C26C2A891333BB069B0DF25654DC982CC558A64163E6DF2EF583AAB829C6D40A05B1558ADA169208998115649EA63BBA9F5010E205C0E011C43B0D73DB15642B3D34896DCE25B14E18FF1E73AB9D9788FF4E4B8962BB14F69C776833804FA4656EEC2327BBDBD41B6F8630E2183EC0018160537DEE3B91EBC9DD7679E9749B9C2E9FA6A823A45BDE34429AA28E50B9BC4303551E68B4A9DC59AC34AC4C56C7A2F616692C2A59BB5EF19E9FA05E97DC9106857AB15854B23A56B94358D1A322550729DF23AC22E5A93CD26CCA8C0C6E62C70D426EEE5C1DD54A63BE7421DB8E796E46A53FE69B210E77CC9711422A2845AA3A52794B9C462A53D591F23021344E9EA685C237AC481C596C64B1DE588CF745DBB2997429479FD5D4A176C36ED585421AA77E09518E48EFC0D378753BF372B4FEF82A3B504EC3644923CB8C2CB30396E9835F7A61967D73CAF0E638D4EE5F65FCCB3705E55823078C1C903F967040B1D8D79600D86D18FDD1DF8870B893A5E27C3F0D52246A90107D9EBD4242F4038DA94E761FA032D3C9D2341CB6E4EE77C5514B5246021B09AC3F022BF78C5A5318B7F9DB82C49A31864A637D7A1CE531D10A0B490F8FCA91E80BBD34169DBEDF1955E5222EBBB8553C18C96D24B7DEC82DDDE66FCB6BD5A328FA9CD6507EA87C361CB7AC1F372ABB5859E1AE344903A3B836598129525FCFD5CCAE47D24859928E05CBEF3A560D589E3A72F2C8C99A9CCC1DB960B314D2B394E27771E4223BEED0FCBD1EEEFC439A250E21E23F233B3EFBB0DC8618BA9338C364F96F67EEA4A78EF20CD7C0434F30C4E9CD7FF3F4F8E494F9F2CF70BEC2330D43DB111C17A14228D49F99D847180314F76E63A002DD4BC854E402EF1904D61A047CEC820E810984A0C9976DBA7FB626C7FEBB0B5EFE4103B6FA344D4C35B8972BE1AD91B82BE19D5AC85DFBEE84C65EED7E44B8F3B5EE668CF69F9619C767FBF179DA0694F90C4BEB41C046E24FFAB5D34758EC1D7F84A577FC919B0E8A9BD44E29BC598E127DCC2311C45D59BA22F3CC9773F33F49C133E3EA5F5FE9B247C66D401CC733E3D8F86F0FDF0151AD4259B25305FAA0AD4AD4BE9155465651639503E313917BD2EA05F63D65E0A28BAA524C51B013C38CE3F7A0C66FED1983373B78DFCE84850964D88D69F8E07D9DF0AAC10FDBB8127490FBDEDEC3C84087C540F50704460E1A90F1674392AB4ACFCB7512CE4732970E8B01CC7304D1C945EC322E12BF3BC2AB393D3092DD9B72B8BA3B4895D8D0DDA6854CFCE736B5E9DB81AC4478EEED0DB2019C7B031E79F62DF36C9FA18AF9E051B591A5761816AD39B0464FF1E25AC55F53B812AE62BE8C3EA2AC1D686861266C963CA0D65E9450100EAC3E58D84ED4AEE9FC66EF3AA772109E17FAF64203B391E3EAA2CABD237D6BBECA35108D1B4E84D437AC73A2688C42137B785AA7746979C86AD725306FCBB7FD8EDCBD96EAF19A0EDF6082E8B291DCD8F78E856172CB175A4E7AA4D172D3D3D164B2F9E8132D492750792E4E015889FCAC8693C867114994C72A6545CAB597132DCF2AAA02FFB976E59A28D541557AA35CCEC07142B91C2289D2C0949C3CDE61E225F2798432F36C8D4299790A2790792E12268EEA3A8C98C1B281230E78C653900AE55388CA21A807171958A80782FB74755D245560C95DE35D744ADF8180C51C208C0031ACAED943D8DFBE3A474EF0B2383B7D76CFABC4F86DD9D05761248D38BEFCE531E2AC455EBCB89EFE5AC010AD4A8819C1F4A05571D38A3C57DE939FFB8C4C8DF22CDC095F0C6CE2C35D04183D010B93C7160CC3E44386BF01274A763D1EA17DE5DD46781361D264E83E3A95BB83B1D759273F09565CADF3EC36394018F6D104524D146F03DC7A971172ECA2DE9F046BED1288D89DCD760FE37789E35DC4D5B640BAE12EE1CA80B2EE2BBCF007E86E1C0216DE7A4B10EF2CE8D78D1893CF7005AC6D7E07500ED2FC22AADD3E5B20B00A801B66186579F293E8B0EDBEFCF817AF9CA4E919A10000, N'6.1.0-30225')
GO
SET IDENTITY_INSERT [dbo].[LoaiBenh] ON 

INSERT [dbo].[LoaiBenh] ([Id], [Code], [Name], [Description], [CreatedAt], [UpdatedAt], [CreatedBy], [UpdatedBy], [IsActive], [IsDelete]) VALUES (1, N'0001', N'Bệnh K', N'Bệnh K', CAST(N'2021-10-29T10:53:41.423' AS DateTime), CAST(N'2021-10-29T10:53:41.423' AS DateTime), NULL, NULL, 1, 0)
SET IDENTITY_INSERT [dbo].[LoaiBenh] OFF
GO
SET IDENTITY_INSERT [dbo].[Medicines] ON 

INSERT [dbo].[Medicines] ([Id], [Code], [Name], [NgayNhap], [Quantity], [GiaBan], [GiaNhap], [CreatedAt], [UpdatedAt], [CreatedBy], [UpdatedBy], [IsActive], [IsDelete]) VALUES (1, N'0001', N'Favirival', CAST(N'2021-10-29T00:00:00.000' AS DateTime), 2, CAST(12000.00 AS Decimal(18, 2)), CAST(10000.00 AS Decimal(18, 2)), CAST(N'2021-10-29T10:57:49.247' AS DateTime), CAST(N'2021-10-29T10:57:49.247' AS DateTime), NULL, NULL, 1, 0)
INSERT [dbo].[Medicines] ([Id], [Code], [Name], [NgayNhap], [Quantity], [GiaBan], [GiaNhap], [CreatedAt], [UpdatedAt], [CreatedBy], [UpdatedBy], [IsActive], [IsDelete]) VALUES (2, N'0002', N'Panadol', CAST(N'2021-10-09T00:00:00.000' AS DateTime), 5, CAST(15000.00 AS Decimal(18, 2)), CAST(130000.00 AS Decimal(18, 2)), CAST(N'2021-10-29T14:18:50.510' AS DateTime), CAST(N'2021-10-29T14:18:50.510' AS DateTime), NULL, NULL, 1, 0)
INSERT [dbo].[Medicines] ([Id], [Code], [Name], [NgayNhap], [Quantity], [GiaBan], [GiaNhap], [CreatedAt], [UpdatedAt], [CreatedBy], [UpdatedBy], [IsActive], [IsDelete]) VALUES (3, N'0003', N'Biosbigloy', CAST(N'2021-10-27T00:00:00.000' AS DateTime), 6, CAST(19000.00 AS Decimal(18, 2)), CAST(15000.00 AS Decimal(18, 2)), CAST(N'2021-10-29T14:19:09.637' AS DateTime), CAST(N'2021-10-29T14:19:09.637' AS DateTime), NULL, NULL, 1, 0)
INSERT [dbo].[Medicines] ([Id], [Code], [Name], [NgayNhap], [Quantity], [GiaBan], [GiaNhap], [CreatedAt], [UpdatedAt], [CreatedBy], [UpdatedBy], [IsActive], [IsDelete]) VALUES (4, N'0004', N'Vitamin-C', CAST(N'2021-10-27T00:00:00.000' AS DateTime), 7, CAST(20000.00 AS Decimal(18, 2)), CAST(18000.00 AS Decimal(18, 2)), CAST(N'2021-10-29T14:19:44.383' AS DateTime), CAST(N'2021-10-29T14:19:44.383' AS DateTime), NULL, NULL, 1, 0)
INSERT [dbo].[Medicines] ([Id], [Code], [Name], [NgayNhap], [Quantity], [GiaBan], [GiaNhap], [CreatedAt], [UpdatedAt], [CreatedBy], [UpdatedBy], [IsActive], [IsDelete]) VALUES (5, N'0005', N'Delxampharay', CAST(N'2021-10-27T00:00:00.000' AS DateTime), 7, CAST(18000.00 AS Decimal(18, 2)), CAST(16000.00 AS Decimal(18, 2)), CAST(N'2021-10-29T14:20:14.660' AS DateTime), CAST(N'2021-10-29T14:20:14.660' AS DateTime), NULL, NULL, 1, 0)
SET IDENTITY_INSERT [dbo].[Medicines] OFF
GO
SET IDENTITY_INSERT [dbo].[Patients] ON 

INSERT [dbo].[Patients] ([Id], [Code], [Name], [Address], [DateOfBirth], [Gender], [Room], [CreatedAt], [UpdatedAt], [CreatedBy], [UpdatedBy], [IsActive], [IsDelete]) VALUES (1, N'0001', N'Bệnh Nhân Số 1', N'HCM', NULL, 0, N'201', CAST(N'2021-10-29T11:01:24.150' AS DateTime), CAST(N'2021-10-29T11:01:24.150' AS DateTime), NULL, NULL, 1, 0)
SET IDENTITY_INSERT [dbo].[Patients] OFF
GO
SET IDENTITY_INSERT [dbo].[PhieuKham] ON 

INSERT [dbo].[PhieuKham] ([Id], [Code], [PatientId], [DoctorId], [TrieuChung], [Price], [NgayTaiKham], [CreatedAt], [UpdatedAt], [CreatedBy], [UpdatedBy], [IsActive], [IsDelete]) VALUES (1, N'0001', 1, 1, N'Ho khàn ra đờm', CAST(50000.00 AS Decimal(18, 2)), NULL, CAST(N'2021-10-29T11:01:24.153' AS DateTime), CAST(N'2021-10-29T11:01:24.153' AS DateTime), NULL, NULL, 1, 0)
SET IDENTITY_INSERT [dbo].[PhieuKham] OFF
GO
SET IDENTITY_INSERT [dbo].[Recipience] ON 

INSERT [dbo].[Recipience] ([Id], [Name], [Description], [PatientId], [CreatedAt], [UpdatedAt], [CreatedBy], [UpdatedBy], [IsActive], [IsDelete]) VALUES (2, N'San Bernardino County1', N'Bệnh K', 1, CAST(N'2021-10-29T15:09:34.163' AS DateTime), CAST(N'2021-10-29T15:20:54.383' AS DateTime), NULL, NULL, 0, 0)
SET IDENTITY_INSERT [dbo].[Recipience] OFF
GO
SET IDENTITY_INSERT [dbo].[RecipienceDetail] ON 

INSERT [dbo].[RecipienceDetail] ([Id], [RecipienceId], [MedicineId], [Quantity], [Price], [CreatedAt], [UpdatedAt], [CreatedBy], [UpdatedBy], [IsActive], [IsDelete]) VALUES (5, 2, 1, 1, CAST(0.00 AS Decimal(18, 2)), CAST(N'2021-10-29T15:20:54.390' AS DateTime), CAST(N'2021-10-29T15:20:54.390' AS DateTime), NULL, NULL, 1, 0)
INSERT [dbo].[RecipienceDetail] ([Id], [RecipienceId], [MedicineId], [Quantity], [Price], [CreatedAt], [UpdatedAt], [CreatedBy], [UpdatedBy], [IsActive], [IsDelete]) VALUES (6, 2, 2, 2, CAST(0.00 AS Decimal(18, 2)), CAST(N'2021-10-29T15:20:54.390' AS DateTime), CAST(N'2021-10-29T15:20:54.390' AS DateTime), NULL, NULL, 1, 0)
SET IDENTITY_INSERT [dbo].[RecipienceDetail] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([Id], [Code], [Name], [Address], [Gender], [Phone], [Position], [DateOfBirth], [Email], [Password], [CreatedAt], [UpdatedAt], [CreatedBy], [UpdatedBy], [IsActive], [IsDelete]) VALUES (1, N'0001', N'Admin', NULL, 1, NULL, 1, NULL, N'admin@gmail.com', N'123456', CAST(N'2021-10-29T14:58:18.313' AS DateTime), CAST(N'2021-10-29T14:58:18.313' AS DateTime), NULL, NULL, 1, 0)
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
/****** Object:  Index [IX_DoctorId]    Script Date: 11/2/2021 9:07:05 AM ******/
CREATE NONCLUSTERED INDEX [IX_DoctorId] ON [dbo].[PhieuKham]
(
	[DoctorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_PatientId]    Script Date: 11/2/2021 9:07:05 AM ******/
CREATE NONCLUSTERED INDEX [IX_PatientId] ON [dbo].[PhieuKham]
(
	[PatientId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_PatientId]    Script Date: 11/2/2021 9:07:05 AM ******/
CREATE NONCLUSTERED INDEX [IX_PatientId] ON [dbo].[Recipience]
(
	[PatientId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_MedicineId]    Script Date: 11/2/2021 9:07:05 AM ******/
CREATE NONCLUSTERED INDEX [IX_MedicineId] ON [dbo].[RecipienceDetail]
(
	[MedicineId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_RecipienceId]    Script Date: 11/2/2021 9:07:05 AM ******/
CREATE NONCLUSTERED INDEX [IX_RecipienceId] ON [dbo].[RecipienceDetail]
(
	[RecipienceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[PhieuKham]  WITH CHECK ADD  CONSTRAINT [FK_dbo.PhieuKham_dbo.Patients_PatientId] FOREIGN KEY([PatientId])
REFERENCES [dbo].[Patients] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PhieuKham] CHECK CONSTRAINT [FK_dbo.PhieuKham_dbo.Patients_PatientId]
GO
ALTER TABLE [dbo].[PhieuKham]  WITH CHECK ADD  CONSTRAINT [FK_dbo.PhieuKham_dbo.Users_DoctorId] FOREIGN KEY([DoctorId])
REFERENCES [dbo].[Users] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PhieuKham] CHECK CONSTRAINT [FK_dbo.PhieuKham_dbo.Users_DoctorId]
GO
ALTER TABLE [dbo].[Recipience]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Recipience_dbo.Patients_PatientId] FOREIGN KEY([PatientId])
REFERENCES [dbo].[Patients] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Recipience] CHECK CONSTRAINT [FK_dbo.Recipience_dbo.Patients_PatientId]
GO
ALTER TABLE [dbo].[RecipienceDetail]  WITH CHECK ADD  CONSTRAINT [FK_dbo.RecipienceDetail_dbo.Medicines_MedicineId] FOREIGN KEY([MedicineId])
REFERENCES [dbo].[Medicines] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RecipienceDetail] CHECK CONSTRAINT [FK_dbo.RecipienceDetail_dbo.Medicines_MedicineId]
GO
ALTER TABLE [dbo].[RecipienceDetail]  WITH CHECK ADD  CONSTRAINT [FK_dbo.RecipienceDetail_dbo.Recipience_RecipienceId] FOREIGN KEY([RecipienceId])
REFERENCES [dbo].[Recipience] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RecipienceDetail] CHECK CONSTRAINT [FK_dbo.RecipienceDetail_dbo.Recipience_RecipienceId]
GO
USE [master]
GO
ALTER DATABASE [DbHospital] SET  READ_WRITE 
GO
