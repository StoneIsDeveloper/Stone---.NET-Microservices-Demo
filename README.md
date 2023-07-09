# Stone---.NET-Microservices-Demo

1. Docker
2. K8S
3. net core 7

### Docker cmd
- docker build -t stone056/platformservice .
- docker run -p 8080:80 -d stone056/platformservice
- docker ps
- docker stop 6b3ed06a23c2
- docker start  6b3ed06a23c2
- docker push stone056/platformservice

### K8s cmd
>kubectl version

- kubectl apply -f platforms-depl.yaml
- kubectl apply -f paltforms-np-srv.yaml
- kubectl apply -f commands-depl.yaml

- kubectl get services
- kubectl get deployments
- kubectl get pods

- kubectl delete deployment platforms-depl
- kubectl delete services platforms-depl
- kubectl rollout restart deployment platforms-depl

