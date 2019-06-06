<template>
  <div>
<!-- Show icon to delete component -->
    <div @click="confirm = true" style="position: absolute; top: -3px; right: 3px;">
      <q-btn size="sm" flat round dense icon="delete">
        <q-tooltip
          transition-show="scale"
          transition-hide="scale"
        >
            Slet denne widget.
        </q-tooltip>

      </q-btn>

    </div>

<!-- Alert box when deleting. persistent === you can't close the popup with esc -->
    <q-dialog v-model="confirm" persistent>
      <q-card>
        <q-card-section class="row items-center">
        <q-avatar icon="delete" color="primary" text-color="white" ></q-avatar>
        <span class="q-ml-sm">Er du sikker på du vil slette denne widget?</span>
        </q-card-section>

        <q-card-actions align="right">
        <q-btn flat label="Fortryd" color="primary" v-close-dialog ></q-btn>
        <q-btn @click="removeItemAndClosePopup({ key: item.i })" flat label="Slet" color="primary" v-close-dialog="confirm"></q-btn>
        </q-card-actions>

      </q-card>
    </q-dialog>
  </div>
</template>

<script>
import { mapActions } from 'vuex'

export default {
  props: ['item'],
  data () {
    return {
      confirm: false
    }
  },
  methods: {
    ...mapActions([
      'removeItem'
    ]),
    removeItemAndClosePopup ({ key: index }) {
      this.confirm = false
      this.removeItem({ key: index }
      )
    }
  }
}
</script>
