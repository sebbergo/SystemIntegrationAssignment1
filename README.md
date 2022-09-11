### Setup

**Step 1: Run the script to start the application**

The file is located in the project root called *StartApplication.sh* as shown below in the directory tree:

```
├── Application
├── Docker
├── React
├── README.md
├── StartApplication.sh
```


> :warning: Make sure that you have docker desktop installed and no instances of a postgres, mongo, redis or neo4j docker container running and these ports should available on your local machine:
> 
> * https://localhost:5001 for Api gateway
> * https://localhost:5002 for Mongo Api
> * https://localhost:5003 for Neo4J Api
> * https://localhost:5004 for Postgres Api
> * https://localhost:5005 for Identity server

 NOTE: The execution of the script will approximately take 2 minutes

**Step 2: Run the test data endpoint if needed**

We have made a endpoint setting up test data for orders in mongoDB if needed which is located at the following URI:

*https://localhost:5001/Gateway/test-data*
