![plot](https://github.com/maxim-polyakov/Azumi_bot/blob/main/House.jpg)

# Azumi_bot

Azumi_bot is a three-layer architecture C# .Net application.

  ## Front layer

  Front layer contains discord and telegram bots to collect data from an environment platforms:
  
  The functional paradigm is realeased in a Front layert. Front layer doesnt comprise entityes, it comprises only functions for implementation commands.
  
    1) TelegramBot
          
    2) Discord_bot
    
    
  ## Core layer

  Core layer comprises a few packages:
  
    1) Answer_package - this package is created for generate answer for input questions. 
    
       Answer_package contains the next entityes:
       
          a) IAnswer
        
    2) Bot_package - this package is created to implement the main bot's logic.
    
       Bot_package contains the next entityes:
       
          a) IToken
          b) IMonitor

        
        
    3) Command_package - this package is created to implement the command's action logic.
    
       Command package contains the next entityes:
       
         a) IAction
         b) ICommandAnalyzer
    
    4) Test_package - this package is created as for testing all application's entities. 
       
       Test package contains the next entityes:
       
         a) ITester

  ## Deep layer

  Deep layer contains a few packages:
  
    1) API_package - this package is created to use API's like googletrans or wikipedia.
    
       API_package comprises the next entityes:
       
          a) ICalculator
          b) IFinder
          c) ITranslator
      
    2) DB_package - this package is created for using several databases.
    
       DB_package contains the next entityes:
       
          a) IDB_Communication
            
    3) NLP_package - this package is created to train NLP models and to use models as predictors.
    
       NLP_package contains the next entityes:
       
          a) IPredictor


  and 1 folder
  
    1) Models
       Models contains the text types of models
          a) Transformer - the transformer model represents encoder-decoder structure but does not rely on recurrence and convolutions in order to generate an output. 
             https://machinelearningmastery.com/the-transformer-model/
          
Also architecture contains SistersMemory - general database which contains samples for models' trainings for all chat_bots which hosted in       https://console.neon.tech/.
