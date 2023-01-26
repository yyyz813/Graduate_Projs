# Plotting

import numpy as np
import matplotlib.pyplot as plt
import Decision_Tree as dec_tree
from sklearn.metrics import confusion_matrix
from sklearn import tree


def Learning_Curves(trn_dir: str, tst_dir: str, max_d: int) -> (float, float):

    # Load the training data
    M = np.genfromtxt(trn_dir, missing_values=0, skip_header=0, delimiter=',', dtype=int)
    y_trn = M[:, 0]
    X_trn = M[:, 1:]

    # Load the testing data
    M = np.genfromtxt(tst_dir, missing_values=0, skip_header=0, delimiter=',', dtype=int)
    y_tst = M[:, 0]
    X_tst = M[:, 1:]

    decision_tree = dec_tree.id3(X_trn, y_trn, max_depth=max_d)  # Learn the tree

    # Calculate the testing errors
    y_pred = [dec_tree.predict_example(x, decision_tree) for x in X_tst]
    tst_err = dec_tree.compute_error(y_tst, y_pred)

    # Calculate the training errors
    y_pred2 = [dec_tree.predict_example(x, decision_tree) for x in X_trn]
    trn_err = dec_tree.compute_error(y_trn, y_pred2)

    return (trn_err, tst_err)

def Self_Data():

    # part e Repeat steps (c) and (d) with your “own” data set
    # Data is pre-processing using its mean μ (statistic under iris.names)

    print("part e: Use own data (iris) to repeat step c and d")
    print("Iris Confusion Matrix with different depth.")

    # Load the training data 85% about 130 datasets
    M = np.genfromtxt('./iris.train', missing_values=0, skip_header=0, delimiter=',', dtype=int)
    y_trn = M[:, 4]   # 4th coloumn
    X_trn = M[:, :3]  # 1-3 coloumn

    # Load the test data 15% about 20 datasets
    M = np.genfromtxt('./iris.test', missing_values=0, skip_header=0, delimiter=',', dtype=int)
    y_tst = M[:, 4]
    X_tst = M[:, :3]

    # repeat part c
    for i in [1, 3, 5]:

        decision_tree = dec_tree.id3(X_trn, y_trn, max_depth=i)  # Learn the tree
        dec_tree.pretty_print(decision_tree)  # print to console

        # Visualized tree
        dot_str = dec_tree.to_graphviz(decision_tree)
        dec_tree.render_dot_file(dot_str, './iris_tree_depth{0}'.format(i))

         # Print confusion matrix
        y_pred = [dec_tree.predict_example(x, decision_tree) for x in X_tst]
        print('iris_depth:' + str(i) + ' confusion_matrix')
        print(confusion_matrix(y_tst, y_pred))


    # repeat part d
    for i in [1, 3, 5]:
        decision_tree = tree.DecisionTreeClassifier(criterion='entropy', max_depth=i)
        decision_tree = decision_tree.fit(X_trn, y_trn)
            # Visualize the tree and save it as a PNG image
        dot_str = tree.export_graphviz(decision_tree, out_file=None)
        dec_tree.render_dot_file(dot_str, './classifier_iris_tree_depth{0}'.format(i))

        # Compute the test error
        y_pred = decision_tree.predict(X_tst)
        print('iris_depth:' + str(i) + ' confusion_matrix')
        print(confusion_matrix(y_tst, y_pred))

if __name__ == '__main__':

    # part b, for each monk problem, learn decision tree from depth 1 to 10.
    # Compute each test and traing errors
    # plot x = depth y = errors. (3 graphs)

    training_data = ['./monks-1.train', './monks-2.train', './monks-3.train']
    testing_data = ['./monks-1.test', './monks-2.test', './monks-3.test']

    for i in range(len(training_data)):

        res_a = []  # Training error list
        res_b = []  # Testing error list

        for j in range(1, 11):
            error = Learning_Curves(training_data[i], testing_data [i], j)
            res_a.append(error[0])
            res_b.append(error[1])

        plt.figure()
        plt.title("monks-{0} Error Graph".format((i + 1)))
        plt.plot(np.arange(1, 11), res_a, marker='o', linewidth=3, markersize=12)
        plt.plot(np.arange(1, 11), res_b, marker='s', linewidth=3, markersize=12)
        plt.xlabel("Depth", fontsize=16)
        plt.ylabel("Training/Testing Error", fontsize=16)
        plt.xticks(np.arange(1, 11), fontsize=12)
        plt.legend(["Training Error", "Testing Error"], fontsize=16)
        plt.axis([0, 12, 0, 1])
        plt.show()

    # part c Weak_Learners
    # For monks-1, depth = 1, 3, 5. Create scikit-learns’s confusion matrix() function
    print("Part_c Monk_1 Confusion Matrix with different depth.")
    # Load the training data
    M = np.genfromtxt('./monks-1.train', missing_values=0, skip_header=0, delimiter=',', dtype=int)
    y_trn = M[:, 0]
    X_trn = M[:, 1:]

    # Load the testing data
    M = np.genfromtxt('./monks-1.test', missing_values=0, skip_header=0, delimiter=',', dtype=int)
    y_tst = M[:, 0]
    X_tst = M[:, 1:]

    for i in [1, 3, 5]:

        decision_tree = dec_tree.id3(X_trn, y_trn, max_depth=i)  # Learn the tree
        dec_tree.pretty_print(decision_tree) # print to console

        # Visualized tree
        dot_str = dec_tree.to_graphviz(decision_tree)
        dec_tree.render_dot_file(dot_str, './monk1_tree_depth{0}'.format(i))

        # Print confusion matrix
        y_pred = [dec_tree.predict_example(x, decision_tree) for x in X_tst]
        print('Monk1_depth:' + str(i) + ' confusion_matrix')
        print(confusion_matrix(y_tst, y_pred))

    # part d use scikit-learn’s DecisionTreeClassifier to learn a decision tree using criterion=’entropy’ for
    # depth = 1, 3, 5. You may use scikit-learn’s confusion matrix() function
    print("Part_d Monk_1 DecisionTreeClassifier with different depth.")

    # Load the training data
    M = np.genfromtxt('./monks-1.train', missing_values=0, skip_header=0, delimiter=',', dtype=int)
    y_trn = M[:, 0]
    X_trn = M[:, 1:]

    # Load the testing data
    M = np.genfromtxt('./monks-1.test', missing_values=0, skip_header=0, delimiter=',', dtype=int)
    y_tst = M[:, 0]
    X_tst = M[:, 1:]

    for i in [1, 3, 5]:
        decision_tree = tree.DecisionTreeClassifier(criterion='entropy', max_depth=i)
        decision_tree = decision_tree.fit(X_trn, y_trn)

        # dec_tree.pretty_print(decision_tree)  # print to console

        # Visualize the tree
        dot_str = tree.export_graphviz(decision_tree, out_file=None)
        dec_tree.render_dot_file(dot_str, './classifier_monk1_tree_depth{0}'.format(i))

        # Compute the test error
        y_pred = decision_tree.predict(X_tst)
        print('Monk1_depth:' + str(i) + ' confusion_matrix')
        print(confusion_matrix(y_tst, y_pred))

    Self_Data()



