<template>
    <q-layout>

        <q-tabs>
            <q-route-tab
                icon="home"
                label="Home"
                to="/"
                exact
            />
            <q-route-tab
                icon="view_compact"
                label="Logskabeloner"
                to="/configuration/create_log"
                exact
            />
            <q-route-tab
                icon="accessibility"
                label="Tags"
                to="/configuration/setup_tags"
                exact
            />
            <q-route-tab
                icon="dashboard"
                label="Dashboard"
                to="/configuration/create_dashboard"
                exact
            />
            <q-route-tab
                icon="developer_board"
                label="Management"
                to="/configuration/setup_management"
                exact
            />
        </q-tabs>

    <q-page-container>
      <router-view />
    </q-page-container>

  </q-layout>
</template>
