cd %CATALINE_HOME%\bin 
set JPDA_ADDRESS=8787 
set JPDA_TRANSPORT=dt_socket 
set CATALINA_OPTS=-server -Xdebug -Xnoagent -Djava.compiler=NONE -Xrunjdwp:transport=dt_socket,server=y,suspend=n,address=8787 
startup