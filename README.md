# Microservice Documentation
This is a proof of concept setting up a Kubernetes cluster with 2 microservices.  
The project is deployed at Google Cloud Platform https://ngc3.rm-group.dk/  

### How To Run the Project
If you don't want to setup a cluster go to the bottom of this page and follow the instructions.
#### Install Docker
1. Follow the instructions here https://docs.docker.com/docker-for-windows/install/  
2. When Docker is installed right click on the Docker icon and be sure that you are using linux containers.  
3. Create a docker account you need it later for your images.  
#### Install kubectl
1. Install Google SDK. Follow the instructions here https://cloud.google.com/sdk/docs/downloads-interactive  
2. Login to the gcloud shell and run this command ```gcloud components update```.  
3. ```gcloud components install kubectl```.  
#### Install Minikube
To install Minikube manually on Windows, download minikube-windows-amd64, rename it to minikube.exe, and add it to your path.  
Download it here https://github.com/kubernetes/minikube/releases/tag/v1.1.0  
Info you need installation instructions for diffrent OS check this link https://kubernetes.io/docs/tasks/tools/install-minikube/  
#### Clone the project
1. When you have cloned the project cd into the root folder.  
2. Open your favorite editor and go to the k8s folder.  
3. Delete certificate.yaml and issuer.yaml. You have to delete these files since I have not configured Minikube to run with SSL.  
4. Open ingress-service.yaml file in the k8s directory.  
5. Comment out following lines in the file: 10, 12, 16, 17, 18 and 19.  
6. Return to your shell and be sure that you arre in the root folder og the project.  
#### Build the images
1. ```docker build -t [<Docker user account>]/quasar-client:latest ./client``` Exampel ```docker build -t bomarconi/quasar-client:latest ./client```    
2. ```docker build -t [<Docker user account>]/formbuilder-server:latest ./R3NextGenBackend/R3NextGenBackend```  
#### Push the Images to Your Docker Account
1. In the shell write ```docker login```  
2. ```docker push [<Docker user account>]/quasar-client:latest```. Exampel ```docker push bomarconi/quasar-client:latest```  
3. ```docker push bomarconi/formbuilder-server:latest```  
#### Change the images to pull in k8s folder
Go back to your editor and open the k8s folder.  
1. Open client-deployment.yaml and change line 19 to ```image: [<Docker user account>]/quasar-client```  
2. Open formbuilder-server-deployment.yaml and change line 17 to ```image: [<Docker user account>]/quasar-client```  
#### Start Minikube
Go back to your shell and be sure that you are in the root folder og the project.  
1. If you are on a Windows OS then write this command ```minikube start --vm-driver=hyperv --hyperv-virtual-switch="Primary Virtual Switch" --v=7 --memory=6000 --alsologtostderr```  
2. If you are on a linux OS write this insted ```minikube start --memory 4000```  
3. Check that Minikube is running ```minikube status```  
4. Get the ip for your Minikube ```minikube ip``` and save it.  
#### Apply the files
1. ```kubectl apply -f k8s```. This applies all the files in the k8s directory.  
2. Go to the ip address in your browser.  
3. ```minikube dashboard``` to see pods, deployments and services.  
Happy hacking :neckbeard:
--- 
## Run the project local as a normal frontend and backend
After you have cloned the project cd into the root folder and open your favorite editor.  
#### Client Project
1. Go to this folder ```client/storeactions```  
2. Comment out line 5 which is this line ```const baseUrl = '/api'```  
3. Remove the comment from line 7 which is this line ```// const baseUrl = 'https://localhost:5001/api'```  
#### R3NextGenBackend Project
1. In the project find the file ```appsettings_notes.txt``` and copy line 2 with the connection string for the local database.  
2. Open the file ```appsettings.json```. Delete line 8 and paste the connection string you just copied at line 8.  
3. Be sure that mssql 2017 is installed on your system https://www.microsoft.com/en-us/sql-server/sql-server-downloads  
4. Be sure Microsoft Visual Studio is installed.  
#### Start the application
1. Start the backend from Microsoft Visual Studio.  
2. Cd into the client folder and write ```npm install```.  
3. ```quasar dev```
#### Run the test suit
1. ```quasar test --unit jest```  
Happy Hacking:sunglasses:  
