<template>
<div class="q-pa-md">
    <div style="position: absolute; top: 17px; left: 1%; width: 98%;">

      <q-input square outlined v-model="text" :label='header' />

    </div>

    <!-- Show icon to change label -->
    <div style="position: absolute; bottom: -3px; right: 25px;">

      <q-btn size="sm" flat round dense icon="edit">
        <q-tooltip
          transition-show="scale"
          transition-hide="scale"
        >
            Skriv overskriften på input feltet her.
        </q-tooltip>
      </q-btn>

      <q-popup-edit v-model="header" buttons label-set="Gem" @save="save" label-cancel="Cancel">
        <q-input v-model="header" dense autofocus counter />
      </q-popup-edit>
    </div>

    <app-lock-component :item="item" />

  </div>
</template>

<script>
import { mapActions } from 'vuex'
import LockComponent from '../helper_components/LockComponent.vue'
export default {
  props: ['item'],
  components: {
    appLockComponent: LockComponent
  },
  data () {
    return {
      text: '',
      header: ''
    }
  },
  methods: {
    ...mapActions([
      'saveInputField'
    ]),
    save () {
      this.item.inputFieldHeader = this.header
      this.saveInputField({ item: this.item, itemIndex: this.itemIndex })
    }
  }

}
</script>
