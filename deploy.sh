# Building the images and add 2 tags for each image ./client/Dockerfile ./R3NextGenBackend/R3NextGenBackend/Dockerfile
docker build -t bomarconi/quasar-client:latest -t bomarconi/quasar-client:$SHA -f ./client/Dockerfile ./client
docker build -t bomarconi/formbuilder-server:latest -t bomarconi/formbuilder-server:$SHA -f ./R3NextGenBackend/R3NextGenBackend/Dockerfile ./R3NextGenBackend/R3NextGenBackend

# Push the images to docker hub
docker push bomarconi/quasar-client:latest
docker push bomarconi/formbuilder-server:latest

docker push bomarconi/quasar-client:$SHA
docker push bomarconi/formbuilder-server:$SHA

# Apply the images to kubernetes
kubectl apply -f k8s

# Make sure that we use the latest image for each container. server- and client-deployments comes from the k8s file
kubectl set image deployments/server-deployment server=bomarconi/formbuilder-server:$SHA
kubectl set image deployments/client-deployment client=bomarconi/quasar-client:$SHA

# Build one image
# docker build -t bomarconi/quasar-client:latest ./client
# docker build -t bomarconi/formbuilder-server:latest ./R3NextGenBackend/R3NextGenBackend
# Push the image to dockerhub
# docker push bomarconi/quasar-client:latest
# docker push bomarconi/formbuilder-server:latest
