<template>
<!-- Tabs for navigation -->
<q-tabs>
<q-route-tab
icon="home"
label="home"
to="/"
exact
/>
<q-route-tab
icon="view_list"
label="hændelser"
to="/incident_logs"
exact
alert="red"
/>
<q-route-tab
icon="build"
label="konfiguration"
to="/configuration/create_log"
exact
/>
</q-tabs>
</template>
