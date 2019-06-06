
const routes = [
  {
    path: '/',
    component: () => import('layouts/DefaultLayout.vue'),
    children: [
      { path: '', component: () => import('pages/Index.vue') },
      { path: '/incident_logs', component: () => import('pages/logs/IncidentLogs.vue') }
    ]
  },
  {
    path: '/configuration',
    component: () => import('layouts/ConfigurationLayout.vue'),
    children: [
      { path: '/configuration/create_log', component: () => import('pages/configuration/LogTemplate.vue') },
      { path: '/configuration/create_dashboard', component: () => import('pages/configuration/DashboardTemplates.vue') },
      { path: '/configuration/setup_management', component: () => import('pages/configuration/ManagementSettings.vue') },
      { path: '/configuration/setup_tags', component: () => import('pages/configuration/TagSettings.vue') }
    ]
  }
]

// Always leave this as last one
if (process.env.MODE !== 'ssr') {
  routes.push({
    path: '*',
    component: () => import('pages/Error404.vue')
  })
}

export default routes
