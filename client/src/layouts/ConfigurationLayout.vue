<template>
  <q-layout>

    <app-side-navigation />

    <!-- Add this if makeing a side navigation! -->
    <!-- <q-page-container> -->
      <!-- This is where pages get injected -->
      <!-- <router-view />
    </q-page-container> -->

  </q-layout>
</template>

<script>

import SideNavigation from './navigation/SideNavigation.vue'
export default {
  // name: 'LayoutName',
  components: {
    appSideNavigation: SideNavigation
  },
  data () {
    return {

    }
  }
}
</script>

<style>
</style>
