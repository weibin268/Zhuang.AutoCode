

CREATE TABLE [dbo].[Sys_AutoCode] (
    [AutoCodeId]  VARCHAR (50)   NOT NULL,
    [Expression]  VARCHAR (500)  NOT NULL,
    [Description] NVARCHAR (500) NULL
);


CREATE TABLE [dbo].[Sys_AutoCodeDetail] (
    [AutoCodeDetailId] VARCHAR (50) NOT NULL,
    [AutoCodeId]       VARCHAR (50) NOT NULL,
    [PrefixCode]       VARCHAR (50) NULL,
    [Seq]              INT          NOT NULL,
    [CreatedDate]      DATETIME     NULL,
    [ModifiedDate]     DATETIME     NULL
);





