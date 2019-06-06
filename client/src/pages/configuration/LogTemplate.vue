<template>
  <q-page padding>

    <h3>Log Template</h3>

    <app-form-builder />

  </q-page>
</template>

<script>
import FormBuilder from '../../components/form_builder/FormBuilder.vue'
import { mapActions } from 'vuex'

export default {
  components: {
    appFormBuilder: FormBuilder
  },
  methods: {
    ...mapActions({
      getInitialLayout: 'getInitialLayout'
    })
  }
  // The created hook allows you to add code which is run if the Vue instance is created.
  // created () {
  // this.getInitialLayout()
  // }

}
</script>
