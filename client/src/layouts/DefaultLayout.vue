<template>
  <q-layout view="lHh Lpr lFf">

    <app-top-navigation />

    <q-page-container>
    <router-view />
    </q-page-container>

  </q-layout>
</template>

<script>

import TopNavigation from './navigation/TopNavigation.vue'
export default {
  components: {
    appTopNavigation: TopNavigation
  },
  name: 'MyLayout',
  data () {
    return {

    }
  },
  methods: {

  }
}
</script>

<style>
</style>
