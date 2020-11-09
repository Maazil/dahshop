<template>
    <section>
        <base-card>
        <h2>Post an item!</h2>
        <item-form></item-form>
        </base-card>
    </section>
</template>

<script>
import ItemForm from '../../components/items/ItemForm.vue';
export default {
    components: {
        ItemForm
    }
}
</script>