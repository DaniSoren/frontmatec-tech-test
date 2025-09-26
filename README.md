Det man kan se i min opgavebesvarelse er følgende:
* Repositoriet er klonet fra CleanArchitecture templaten.
* Der er lavet en ProcessCell aggregate.
* Der er forsøgt at lave en CreateProcessCellCommand. Det lykkedes mig aldrig at kunne få det skrevet ned i selve databasen. Mit problem er, at jeg ikke kan få ProcessCellProperties dictionary skrevet ned til databasen, hvor jeg selv forsøgte at lave dictionariet til en liste i stedet, hvilket ikke fiksede det.
* Der er forsøgt at lave en CreateProcessCellEndpoint. Da jeg ikke kan skrive ned i databasen jf. forrige pointe har jeg ikke kunne teste, om dette går igennem.


De ændringer, jeg selv har foretaget mig findes i dette commit: https://github.com/DaniSoren/frontmatec-tech-test/commit/3f49782571959c969580a1339172d60f9ba3af73

Det drejer sig primært om flg. filer.
* ‎src/FrontmatecTechTest.Core/ProcessCell.cs
* ‎src/FrontmatecTechTest.Core/ProcessCellProperty.cs
* src/FrontmatecTechTest.UseCases/CreateProcessCellCommand.cs
* ‎src/FrontmatecTechTest.Web/CreateProcessCellEndpoint.cs