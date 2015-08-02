ALTER DATABASE [$(DatabaseName)]
    ADD LOG FILE (NAME = [phalanx_Log], FILENAME = '$(DefaultLogPath)$(DatabaseName)_log.ldf', FILEGROWTH = 10 %);

