k8s_yaml([
	'k8s/client-cluster-ip-service.yaml',
	'k8s/client-deployment.yaml',
	'k8s/database-formbuilder-persistent-volume-claim.yaml',
	'k8s/formbuilder-server-cluster-ip-service.yaml',
	'k8s/formbuilder-server-deployment.yaml', 'k8s/ingress-service.yaml'
])

docker_build(
	'bomarconi/quasar-client',
	'client',
	dockerfile='client/Dockerfile.dev')
	docker_build('bomarconi/formbuilder-server', 'server-deployment',
	dockerfile='R3NextGenBackend/R3NextGenBackend/Dockerfile.dev'
)
