ALTER DATABASE [$(DatabaseName)]
    ADD FILE (NAME = [phalanx_Data], FILENAME = '$(DefaultDataPath)$(DatabaseName).mdf', FILEGROWTH = 10 %) TO FILEGROUP [PRIMARY];

