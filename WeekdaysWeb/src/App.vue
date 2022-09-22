<template>
    <div id="app">
        <button @click="DisplayAction">Display</button>
        <button @click="EditAction">Edit</button>
        <display-component v-if="ShowDisplayComponent" />
        <edit-component v-if="ShowEditComponent" />
    </div>
</template>

<script>
    import DisplayComponent from './components/Display'
    import EditComponent from './components/Edit'
    export default {
        name: "App",
        components: {
            DisplayComponent,
            EditComponent
        },
        data() {
            return {
                ShowDisplayComponent: true,
                ShowEditComponent: false
            };
        },
        methods: {
            DisplayAction() {
                this.ShowEditComponent = false;
                this.ShowDisplayComponent = !this.ShowDisplayComponent;
            },
            EditAction() {
                this.ShowEditComponent = !this.ShowEditComponent;
                this.ShowDisplayComponent = false;
            }
        }
    };
</script>
